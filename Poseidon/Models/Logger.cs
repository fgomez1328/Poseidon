//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Poseidon.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Logger
    {
        public int logger_id { get; set; }
        public string logger_sites_name { get; set; }
        public Nullable<int> logger_sms { get; set; }
        public Nullable<int> logger_type { get; set; }
        public string logger_serial_number { get; set; }
        public Nullable<int> instalation_type { get; set; }
        public Nullable<int> chip_id { get; set; }
        public string latitude { get; set; }
        public string longitute { get; set; }
        public Nullable<double> elevation { get; set; }
        public string antenna_position { get; set; }
        public Nullable<int> final_csq { get; set; }
        public Nullable<bool> gprs_test_status { get; set; }
        public Nullable<System.DateTime> creation_date { get; set; }
        public Nullable<int> creation_user { get; set; }
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
        public Nullable<bool> logger_outdoor { get; set; }
        public string condition_type_instalation { get; set; }
        public Nullable<int> antenna_type { get; set; }
        public Nullable<bool> Csq_outdoor { get; set; }
        public Nullable<bool> can_lamppost_with_antenna { get; set; }
        public string manometer_aar_value { get; set; }
        public string logger_aar_value { get; set; }
        public string manometer_aab_value { get; set; }
        public string logger_aab_value { get; set; }
        public string flowmetter_status { get; set; }
        public Nullable<bool> with_pulser { get; set; }
        public Nullable<bool> pulser_changed { get; set; }
        public string liters_per_pulser { get; set; }
        public string logger_position { get; set; }
        public Nullable<bool> flooded_chamber { get; set; }
        public string chamber_condition { get; set; }
        public string chamber_cap { get; set; }
        public Nullable<bool> necessary_drain { get; set; }
        public Nullable<bool> necessary_manipulate_traffic { get; set; }
        public Nullable<bool> necessary_tool_open_chamber { get; set; }
        public Nullable<bool> two_thechnical_open_chamber { get; set; }
        public Nullable<int> channel_1 { get; set; }
        public Nullable<int> channel_2 { get; set; }
        public Nullable<int> channel_3 { get; set; }
        public Nullable<int> channel_4 { get; set; }
        public Nullable<bool> battery_installed { get; set; }
        public string battery_serial_number { get; set; }
        public string notes { get; set; }
        public string site_conditions_installation { get; set; }
        public Nullable<int> id_conditions_installation { get; set; }
        public Nullable<int> chamber_type_id { get; set; }
        public Nullable<int> chamber_type_tap_id { get; set; }
        public string battery_type { get; set; }
        public Nullable<int> state_flowmeter_id { get; set; }
        public Nullable<int> type_flowmeter_id { get; set; }
        public string picture_image { get; set; }
        public string picture_url { get; set; }
        public string instalation_type_logger { get; set; }
    
        public virtual Company Company { get; set; }
    }
}
