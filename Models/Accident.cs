using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// this coordinates with our database

namespace INTEX2.Models
{
    public class Accident
    {
        [Key]
        public int CRASH_ID { get; set; }
        public string MONTH { get; set; }
        public string DAY_OF_WEEK { get; set; }
        public int YEAR { get; set; }
        public Nullable<int> HOUR { get; set; }
        public string ROUTE { get; set; }
        public float MILEPOINT { get; set; }
        public string LAT_UTM_Y { get; set; }
        public string LONG_UTM_X { get; set; }
        public string MAIN_ROAD_NAME { get; set; }
        public string CITY { get; set; }
        public string COUNTY_NAME { get; set; }
        public int CRASH_SEVERITY_ID { get; set; }
        public float WORK_ZONE_RELATED { get; set; }
        public float PEDESTRIAN_INVOLVED { get; set; }
        public float BICYCLIST_INVOLVED { get; set; }
        public float MOTORCYCLE_INVOLVED { get; set; }
        public float IMPROPER_RESTRAINT { get; set; }
        public float UNRESTRAINED { get; set; }
        public float DUI { get; set; }
        public float INTERSECTION_RELATED { get; set; }
        public float WILD_ANIMAL_RELATED { get; set; }
        public float DOMESTIC_ANIMAL_RELATED { get; set; }
        public float OVERTURN_ROLLOVER { get; set; }
        public float COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }
        public float TEENAGE_DRIVER_INVOLVED { get; set; }
        public float OLDER_DRIVER_INVOLVED { get; set; }
        public float NIGHT_DARK_CONDITION { get; set; }
        public float SINGLE_VEHICLE { get; set; }
        public float DISTRACTED_DRIVING { get; set; }
        public float DROWSY_DRIVING { get; set; }
        public float ROADWAY_DEPARTURE { get; set; }

        // this relates to our ML model and our onnx file, and allows it to process the inputs from predictor
        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                MOTORCYCLE_INVOLVED, PEDESTRIAN_INVOLVED, OVERTURN_ROLLOVER, BICYCLIST_INVOLVED, UNRESTRAINED, INTERSECTION_RELATED,
                DUI, NIGHT_DARK_CONDITION, ROADWAY_DEPARTURE, SINGLE_VEHICLE
            };
            int[] dimensions = new int[] { 1, 10 };
            return new DenseTensor<float>(data, dimensions);
            
        }
    }
}
