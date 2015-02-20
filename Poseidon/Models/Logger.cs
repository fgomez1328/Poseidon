namespace Poseidon.Models
{

    using System;

    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;




    public partial class Logger
    {

        public int logger_id { get; set; }

        public string logger_sites_name { get; set; }

        public Nullable<int> logger_sms { get; set; }

        public Nullable<int> logger_type { get; set; }

        public string logger_serial_number { get; set; }

        public Nullable<int> instalation_type { get; set; }

        public Nullable<int> chip_id { get; set; }
      

        [Required(ErrorMessage = "El campo Latitude es requerido")]
        
        public string latitude { get; set; }


         [Required(ErrorMessage = "El campo Longitute es requerido")]
        public string longitute { get; set; }

        [Required(ErrorMessage = "El campo elevation es requerido")]
        public Nullable<double> elevation { get; set; }

        [Required(ErrorMessage = "El campo antenna_position es requerido")]
        public string antenna_position { get; set; }

         [Required(ErrorMessage = "El campo final_csq es requerido")]
        public Nullable<int> final_csq { get; set; }

        [Required(ErrorMessage = "El campo gprs_test_status es requerido")]
        public Nullable<bool> gprs_test_status { get; set; }

         [Required(ErrorMessage = "El campo creation_date es requerido")]
        public Nullable<System.DateTime> creation_date { get; set; }

        public Nullable<int> creation_user { get; set; }

        [Required(ErrorMessage = "El campo type_flowmeter_id es requerido")]
        public Nullable<int> type_flowmeter_id { get; set; }
       

        public Nullable<System.DateTime> instalation_date { get; set; }

        public Nullable<int> instalation_user { get; set; }

        public Nullable<System.DateTime> approval_date { get; set; }

        public Nullable<int> approval_user { get; set; }

        public int company_id { get; set; }

        [Required(ErrorMessage = "El campo url_image es requerido")]
        public string url_image { get; set; }

        [Required(ErrorMessage = "El campo status es requerido")]
        public Nullable<int> status { get; set; }


            [Required(ErrorMessage = "El campo  location_name requerido")]
        public string location_name { get; set; }

       
        public string location_id { get; set; }

        public Nullable<bool> necessary_key { get; set; }

        public string contact_detail { get; set; }

        public string zone_name { get; set; }

        public string zone_code { get; set; }

        public string sites_name { get; set; }

        public Nullable<bool> key_ball { get; set; }

        public Nullable<int> zone_id { get; set; }

        public Nullable<int> user_instalation { get; set; }

        public Nullable<System.DateTime> user_instalation_start_date { get; set; }

        public Nullable<System.DateTime> user_instalation_end_date { get; set; }

        public Nullable<bool> necesary_site_enter { get; set; }

        public bool NoNullExclusive
        {

            get { return necesary_site_enter ?? false; }

            set { necesary_site_enter = value; }

        }

       




        public Nullable<bool> logger_outdoor { get; set; }



         [Required(ErrorMessage = "El campo  NoNulllogger_outdoor requerido")]
        public bool NoNulllogger_outdoor
        {

            get { return logger_outdoor ?? false; }

            set { logger_outdoor = value; }

        }


         [Required(ErrorMessage = "El campo  condition_type_instalation requerido")]
        public string condition_type_instalation { get; set; }

        public int antenna_type { get; set; }

        public int antenna_type_id { get; set; }



        public Nullable<bool> Csq_outdoor { get; set; }


        [Required(ErrorMessage = "El campo  NoNullCsq_outdoor requerido")]
        public bool NoNullCsq_outdoor
        {

            get { return Csq_outdoor ?? false; }

            set { Csq_outdoor = value; }

        }







        public Nullable<bool> can_lamppost_with_antenna { get; set; }


          [Required(ErrorMessage = "El campo  NoNullcan_lamppost_with_antenna requerido")]
        public bool NoNullcan_lamppost_with_antenna
        {

            get { return can_lamppost_with_antenna ?? false; }

            set { can_lamppost_with_antenna = value; }

        }








         [Required(ErrorMessage = "El campo   manometer_aar_ es requerido")]
        public string manometer_aar_value { get; set; }


         [Required(ErrorMessage = "El campo  logger_aar_value es requerido")]
        public string logger_aar_value { get; set; }


         [Required(ErrorMessage = "El campo  manometer_aab_value es requerido")]
        public string manometer_aab_value { get; set; }


         [Required(ErrorMessage = "El campo  logger_aab_value es requerido")]
        public string logger_aab_value { get; set; }


          [Required(ErrorMessage = "El campo  flowmetter_status es requerido")]
        public string flowmetter_status { get; set; }

      [Required(ErrorMessage = "El campo  with_pulser es requerido")]
        public Nullable<bool> with_pulser { get; set; }

        [Required(ErrorMessage = "El campo NoNullwith_pulser es requerido")]
        public bool NoNullwith_pulser
        {

            get { return with_pulser ?? false; }

            set { with_pulser = value; }

        }





        public Nullable<bool> pulser_changed { get; set; }

        [Required(ErrorMessage = "El campo NoNullpulser_changed es requerido")]
        public bool NoNullpulser_changed
        {

            get { return pulser_changed ?? false; }

            set { pulser_changed = value; }

        }








        [Required(ErrorMessage = "El campo site_conditions_installation es requerido")]
        public string site_conditions_installation { get; set; }

        public int id_conditions_installation { get; set; }


         [Required(ErrorMessage = "El campo liters_per_pulser es requerido")]
        public string liters_per_pulser { get; set; }


         [Required(ErrorMessage = "El campo logger_position es requerido")]
        public string logger_position { get; set; }

        public Nullable<bool> flooded_chamber { get; set; }

        [Required(ErrorMessage = "El campo chamber_condition es requerido")]
        public string chamber_condition { get; set; }


         [Required(ErrorMessage = "El campo chamber_condition_id es requerido")]
        public int chamber_condition_id { get; set; }

        [Required(ErrorMessage = "El campo chamber_cap es requerido")]
        public string chamber_cap { get; set; }

        [Required(ErrorMessage = "El campo chamber_type_id es requerido")]
        public int chamber_type_id { get; set; }


          [Required(ErrorMessage = "El campo chamber_type_tap_id es requerido")]
        public int chamber_type_tap_id { get; set; }


         [Required(ErrorMessage = "El campo  NoNullflooded_chamber es requerido")]
        public bool NoNullflooded_chamber
        {

            get { return flooded_chamber ?? false; }

            set { flooded_chamber = value; }

        }







        public Nullable<bool> necessary_drain { get; set; }


          [Required(ErrorMessage = "El campo NoNullnecessary_drain es requerido")]
        public bool NoNullnecessary_drain
        {

            get { return necessary_drain ?? false; }

            set { necessary_drain = value; }

        }


         [Required(ErrorMessage = "El campo   state_flowmeter_id es requerido")]
        public int state_flowmeter_id { get; set; }

        public int type_state_flowmeter_id { get; set; }



        public Nullable<bool> necessary_manipulate_traffic { get; set; }


         [Required(ErrorMessage = "El campo   NoNullnecessary_manipulate_traffic es requerido")]
        public bool NoNullnecessary_manipulate_traffic
        {

            get { return necessary_manipulate_traffic ?? false; }

            set { necessary_manipulate_traffic = value; }

        }





        public Nullable<bool> necessary_tool_open_chamber { get; set; }


         [Required(ErrorMessage = "El campo  NoNullnecessary_tool_open_chamber es requerido")]
        public bool NoNullnecessary_tool_open_chamber
        {

            get { return necessary_tool_open_chamber ?? false; }

            set { necessary_tool_open_chamber = value; }

        }





        public Nullable<bool> two_thechnical_open_chamber { get; set; }



          [Required(ErrorMessage = "El campo  NoNulltwo_thechnical_open_chamber es requerido")]
        public bool NoNulltwo_thechnical_open_chamber
        {

            get { return two_thechnical_open_chamber ?? false; }

            set { two_thechnical_open_chamber = value; }

        }

        public Nullable<bool> is_necessary_tool_open_chamber { get; set; }


         [Required(ErrorMessage = "El campo NoNullis_necessary_tool_open_chamber es requerido")]
        public bool NoNullis_necessary_tool_open_chamber
        {

            get { return is_necessary_tool_open_chamber ?? false; }

            set { is_necessary_tool_open_chamber = value; }

        }







        public int channel_1 { get; set; }

        public int channel_id_1 { get; set; }




       
        public int channel_2 { get; set; }

         [Required(ErrorMessage = "El campo channel_id_2 es requerido")]
        public int channel_id_2 { get; set; }

        public int channel_3 { get; set; }

        public int channel_id_3 { get; set; }

        public int channel_4 { get; set; }

        public int channel_id_4 { get; set; }

        public Nullable<bool> battery_installed { get; set; }

        public bool NoNullbattery_installed
        {

            get { return battery_installed ?? false; }

            set { battery_installed = value; }

        }




         [Required(ErrorMessage = "El campo battery_type es requerido")]
        public string battery_type { get; set; }

         [Required(ErrorMessage = "El campo battery_serial_number es requerido")]
        public string battery_serial_number { get; set; }

        [Required(ErrorMessage = "El campo notes es requerido")]
        public string notes { get; set; }



        public virtual Company Company { get; set; }

         [Required(ErrorMessage = "El campo picture_image es requerido")]
        public string picture_image { get; set; }

        [Required(ErrorMessage = "El campo picture_url es requerido")]
        public string picture_url { get; set; }




      
    }

}

