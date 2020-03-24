using System;
using System.Collections.Generic;
using System.Linq;
using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using System.Windows.Forms;
using BlackBox.Forms;

namespace BlackBox
{
    public class BlackBoxCommand : Command
    {
        public BlackBoxCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static BlackBoxCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "BlackBoxCommand"; }
        }

        public const int AREA_PER_HUMAN = 18;
        public const int AREA_PER_FAMILY = 15;

        public const float ONE_MEMBER_FAMILY_PERCENT = 0.3F;
        public const float THREE_MEMBERS_FAMILY_PERCENT = 0.4F;
        public const float TWO_MEMBERS_FAMILY_PERCENT = 0.3F;

        public const string ADDRESS = "ads_lahiaa";
        public const string APARTMENTS_PERHOUSE = "korterelamud_info_Kortereid kokku";
        public const string EHR_ID = "ehr_gid";
        public const string ELECTRICITY_WITHOUT_CONTRACT_PERCENT = "e_lepinguta_%";
        public const string ETAK_ID = "etak_id";
        public const string GOVERNMENT_OWNED_COUNT = "katastrid copy_loobutud_vara_count";
        public const string LIVING_AREA_PERHOUSE = "korterelamud_info_Eluruumide pindala (m2)";
        public const string UNINHABITED_PERCENT = "e_asustamata_%%";

        protected override Result RunCommand(Rhino.RhinoDoc doc, RunMode mode)
        {
            //TODO: To implement?
            var apartmentHousesPercetage = new double();

            ObjRef[] srcCurves;

            RhinoGet.GetMultipleObjects("ClosedPolygones", false, ObjectType.Curve, out srcCurves);

            var dicts = new Dictionary<Guid, DataDto>();
            for (var i = 0; i < srcCurves.Count(); i++)
            {
                var o = GetDto(srcCurves[i]);
                dicts.Add(srcCurves[i].ObjectId, o);
            }

            if (mode == RunMode.Interactive)
            {
                var form = new CalcForm { StartPosition = FormStartPosition.CenterParent };
                while (form.ShowDialog() != DialogResult.OK)
                {
                    RhinoApp.WriteLine("Insert population into form");
                    CalculateOverstock(form, dicts);
                }
            }
            else
            {
                var msg = string.Format("", EnglishName);
                RhinoApp.WriteLine(msg);
            }

            return Result.Success;
        }

        public void CalculateOverstock(CalcForm form, Dictionary<Guid, DataDto> dicts)
        {
            var population = form.GetPopulation(form);
            var optimalLivingArea = GetOptimalLivingArea(population, 0.9F);
            var excistingLivingArea = GetExcistingLivingArea(dicts);

            if (optimalLivingArea > 0 && excistingLivingArea > 0)
            {
                var overStockPercent = (excistingLivingArea - optimalLivingArea) * 100 / excistingLivingArea;

                RhinoApp.WriteLine($"Overstock {overStockPercent} percent");

                form.InsertOverStockValue(form, overStockPercent);
            }

            else
            {
                RhinoApp.WriteLine($"No info to calculate overstock percent");
            }
        }

        public int GetOptimalLivingArea(int population, double apartmentHousesPercetage)
        {
            var optimalArea = new int();

            var populationLivingInApartements = population * apartmentHousesPercetage;

            var optimalLivingAreaForOneMember = (populationLivingInApartements * ONE_MEMBER_FAMILY_PERCENT)
                * (AREA_PER_HUMAN + AREA_PER_FAMILY);

            var optimalLivingAreaForTwoMembers = (populationLivingInApartements * TWO_MEMBERS_FAMILY_PERCENT)
                * (AREA_PER_HUMAN + AREA_PER_FAMILY / 2);

            var optimalLivingAreaForThreeMembers = (populationLivingInApartements * THREE_MEMBERS_FAMILY_PERCENT)
                * (AREA_PER_HUMAN + AREA_PER_FAMILY / 3);

            optimalArea = (int)Math.Round(optimalLivingAreaForOneMember + optimalLivingAreaForTwoMembers + optimalLivingAreaForThreeMembers);

            return optimalArea;
        }

        public int GetExcistingLivingArea(Dictionary<Guid, DataDto> housingStockInfo)
        {
            var livingArea = new int();

            livingArea = housingStockInfo
                .Where(x => x.Value.LivingAreaPerHouse != null)
                .Sum(x => x.Value.LivingAreaPerHouse.Value);

            return livingArea;
        }

        public DataDto GetDto(ObjRef o)
        {
            var dict = o.Object().Attributes.UserDictionary;

            var dataDto = new DataDto
            {
                EtakId = Convert.ToInt32(dict.Where(x => x.Key == ETAK_ID).FirstOrDefault().Value),
                Address = dict.Where(x => x.Key == EHR_ID).FirstOrDefault().Value.ToString(),
                ApartmentsCount = Convert.ToInt32(dict.Where(x => x.Key == APARTMENTS_PERHOUSE).FirstOrDefault().Value),
                EhrId = Convert.ToInt32(dict.Where(x => x.Key == EHR_ID).FirstOrDefault().Value),
                GovernmentOwnedCount = Convert.ToInt32(dict.Where(x => x.Key == GOVERNMENT_OWNED_COUNT).FirstOrDefault().Value),
                LivingAreaPerHouse = Convert.ToInt32(dict.Where(x => x.Key == LIVING_AREA_PERHOUSE).FirstOrDefault().Value),
                NoElectricityPercent = Convert.ToInt32(dict.Where(x => x.Key == ELECTRICITY_WITHOUT_CONTRACT_PERCENT).FirstOrDefault().Value),
                UnInhabitedPercent = Convert.ToInt32(dict.Where(x => x.Key == UNINHABITED_PERCENT).FirstOrDefault().Value),
            };

            return dataDto;
        }

        public class DataDto
        {
            public int EtakId { get; set; }

            public string Address { get; set; }
            public int? ApartmentsCount { get; set; }
            public int? EhrId { get; set; }
            public int? GovernmentOwnedCount { get; set; }
            public int? LivingAreaPerHouse { get; set; }
            public int? NoElectricityPercent { get; set; }
            public int? UnInhabitedPercent { get; set; }
        }
    }
}

