namespace Poseidon.Models
{

    using System;

    using System.Collections.Generic;
    using System.ComponentModel;




    public partial class Logger
    {

        public int logger_id { get; set; }

        public string logger_sites_name { get; set; }

        public Nullable<int> logger_sms { get; set; }

        public Nullable<int> logger_type { get; set; }

        public string logger_serial_number { get; set; }

        public Nullable<int> instalation_type { get; set; }

        public Nullable<int> chip_id { get; set; }
        [DisplayName("Latitude")]
        public string latitude { get; set; }

        public string longitute { get; set; }

        public Nullable<double> elevation { get; set; }

        public string antenna_position { get; set; }

        public Nullable<int> final_csq { get; set; }

        public Nullable<bool> gprs_test_status { get; set; }

        public Nullable<System.DateTime> creation_date { get; set; }

        public Nullable<int> creation_user { get; set; }
        public Nullable<int> type_flowmeter_id { get; set; }
       

        public Nullable<System.DateTime> instalation_date { get; set; }

        public Nullable<int> instalation_user { get; set; }

        public Nullable<System.DateTime> approval_date { get; set; }

        public Nullable<int> approval_user { get; set; }

        public int company_id { get; set; }

        public string url_image { get; set; }

        public Nullable<int> status { get; set; }

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



        public bool NoNulllogger_outdoor
        {

            get { return logger_outdoor ?? false; }

            set { logger_outdoor = value; }

        }







        public string condition_type_instalation { get; set; }

        public int antenna_type { get; set; }

        public int antenna_type_id { get; set; }



        public Nullable<bool> Csq_outdoor { get; set; }



        public bool NoNullCsq_outdoor
        {

            get { return Csq_outdoor ?? false; }

            set { Csq_outdoor = value; }

        }







        public Nullable<bool> can_lamppost_with_antenna { get; set; }



        public bool NoNullcan_lamppost_with_antenna
        {

            get { return can_lamppost_with_antenna ?? false; }

            set { can_lamppost_with_antenna = value; }

        }









        public string manometer_aar_value { get; set; }

        public string logger_aar_value { get; set; }

        public string manometer_aab_value { get; set; }

        public string logger_aab_value { get; set; }

        public string flowmetter_status { get; set; }

        public Nullable<bool> with_pulser { get; set; }

        public bool NoNullwith_pulser
        {

            get { return with_pulser ?? false; }

            set { with_pulser = value; }

        }





        public Nullable<bool> pulser_changed { get; set; }



        public bool NoNullpulser_changed
        {

            get { return pulser_changed ?? false; }

            set { pulser_changed = value; }

        }









        public string site_conditions_installation { get; set; }

        public int id_conditions_installation { get; set; }

        public string liters_per_pulser { get; set; }

        public string logger_position { get; set; }

        public Nullable<bool> flooded_chamber { get; set; }

        public string chamber_condition { get; set; }

        public int chamber_condition_id { get; set; }

        public string chamber_cap { get; set; }

        public int chamber_type_id { get; set; }

        public int chamber_type_tap_id { get; set; }



        public bool NoNullflooded_chamber
        {

            get { return flooded_chamber ?? false; }

            set { flooded_chamber = value; }

        }







        public Nullable<bool> necessary_drain { get; set; }



        public bool NoNullnecessary_drain
        {

            get { return necessary_drain ?? false; }

            set { necessary_drain = value; }

        }



        public int state_flowmeter_id { get; set; }

        public int type_state_flowmeter_id { get; set; }



        public Nullable<bool> necessary_manipulate_traffic { get; set; }



        public bool NoNullnecessary_manipulate_traffic
        {

            get { return necessary_manipulate_traffic ?? false; }

            set { necessary_manipulate_traffic = value; }

        }





        public Nullable<bool> necessary_tool_open_chamber { get; set; }



        public bool NoNullnecessary_tool_open_chamber
        {

            get { return necessary_tool_open_chamber ?? false; }

            set { necessary_tool_open_chamber = value; }

        }





        public Nullable<bool> two_thechnical_open_chamber { get; set; }

        public bool NoNulltwo_thechnical_open_chamber
        {

            get { return two_thechnical_open_chamber ?? false; }

            set { two_thechnical_open_chamber = value; }

        }

        public Nullable<bool> is_necessary_tool_open_chamber { get; set; }



        public bool NoNullis_necessary_tool_open_chamber
        {

            get { return is_necessary_tool_open_chamber ?? false; }

            set { is_necessary_tool_open_chamber = value; }

        }







        public int channel_1 { get; set; }

        public int channel_id_1 { get; set; }





        public int channel_2 { get; set; }

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





        public string battery_type { get; set; }

        public string battery_serial_number { get; set; }

        public string notes { get; set; }



        public virtual Company Company { get; set; }

        public string picture_image { get; set; }

        public string picture_url { get; set; }




      
    }

}

