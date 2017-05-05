using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.Services;


namespace SongCatelogApp
{
    public partial class profile1 : System.Web.UI.Page
    {
        public DBConnection DBUtils = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    int i = 0;
            //    DataTable dt = new DataTable();
            //    string userId = "10394";
            //    //string sql = "SELECT * from mpm_Users where id=10394";
            //    //DataTable dtt = DBUtils.ExecuteQuery(sql);
            //    string weburl = System.Configuration.ConfigurationManager.ConnectionStrings["WebURL"].ConnectionString;
            //    //ProfilePic.ImageUrl = weburl + "Profile_Image/" + userId + ".jpg";
            //    //ProfilePic.ImageUrl = "http://app.hitlicense.com/Profile_Image/" + userId + ".jpg";

            //    //txtName.Text = dtt.Rows[0]["name"].ToString();
            //    //txtEmail.Text = dtt.Rows[0]["email"].ToString();
            //    //txtPhone.Text = dtt.Rows[0]["phone"].ToString();
            //    System.Web.UI.HtmlControls.HtmlGenericControl createDivMySong = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            //    //createDivMySong.InnerHtml += "        <script>"+
            //    //"jQuery(document).ready(function($) { var settings_ap = { disable_volume: 'off' , disable_scrub: 'default'                    , design_skin: 'skin-wave'                    , skinwave_dynamicwaves: 'off'                    , skinwave_enableSpectrum: 'off'                    , settings_backup_type: 'full'                    , skinwave_enableReflect: 'on'                    , skinwave_comments_enable: 'on'                };                dzsag_init('#ag1', {                    'transition': 'fade'                    , 'autoplay': 'on'                    , 'autoplayNext': 'on'                    , design_menu_position: 'bottom'                    , 'settings_ap': settings_ap                    , design_menu_state: 'closed'                    , design_menu_show_player_state_button: 'on'                });            });        </script>";

            //    string sql2 = "SELECT * FROM mpm_Songs left join song_peaks on song_peaks.songId=mpm_Songs.id WHERE mpm_Songs.uploader='5' and mpm_Songs.status!=10    order by mpm_Songs.CreateDate desc";
            //    dt = this.DBUtils.ExecuteQuery(sql2);

            //    //createDivMySong.InnerHtml += "<div id='ag1' class='audiogallery skin-default' style='opacity:0; margin-top: 70px;'><div class='items'>";
            //    createDivMySong.InnerHtml = "  <div class='gmedia_gallery wavesurfer_module' id='GmediaGallery_706' data-gmid='706' data-module='wavesurfer'>"+
            //                                    "<div class='ws-soundList ws-compact'>";
            //    for (i = 0; i < dt.Rows.Count; i++)
            //    {
            //        string id = dt.Rows[i][0].ToString();
            //        string songtitle = dt.Rows[i][1].ToString();
            //        string artist = dt.Rows[i][2].ToString();
            //        string peaks = "[]";
            //        if (dt.Rows[i][35].ToString() != null && dt.Rows[i][35].ToString()!="")
            //        {
            //            peaks = dt.Rows[i][35].ToString();
            //        }
                    
            //        createDivMySong.InnerHtml += "<div class='ws-soundList__item ws-have-cover' data-id='"+id+"'>"+
            //                                            "<div role='group' class='ws-sound'>"+
            //                                                "<div class='ws-sound__body'>"+
            //                                                    "<div class='ws-sound__artwork'>"+
            //                                                        "<a class='ws-sound__coverArt' href='javascript:void(0)' data-cover='background-image: url('http://testapp.hitlicense.com/Profile_Image/" + userId + ".jpg');'>" +
            //                                                           "<span class='ws-image ws-artwork ws-artwork-placeholder'>"+
            //                                                                "<span style='background-image: url(&quot;http://testapp.hitlicense.com/Profile_Image/"+userId+".jpg&quot;);' class='ws-artwork ws-image__thumb' aria-role='img'></span>" +
            //                                                            "</span>"+
            //                                                        "</a>"+
            //                                                    "</div>"+
            //                                                    "<div class='ws-sound__content'>"+
            //                                                        "<div class='ws-visualSound__wrapper '>"+
            //                                                            "<div class='ws-sound__header'>"+
            //                                                                "<div class='ws-soundTitle ws-clearfix'>"+
            //                                                                    "<div class='ws-soundTitle__titleContainer'>"+
            //                                                                        "<div class='ws-soundTitle__playButton'>"+
            //                                                                            "<span class='ws-button ws-button-play' tabindex='0' title='Play'>Play</span>"+
            //                                                                        "</div>"+
            //                                                                        "<div class='ws-soundTitle__titleWrapper'>"+
            //                                                                            "<div class='ws-soundTitle__secondary ws-type-light'></div>"+
            //                                                                            "<span>"+songtitle+"</span>"+
            //                                                                        "</div>"+
            //                                                                    "</div>"+
            //                                                                "</div>"+
            //                                                            "</div>"+
            //                                                            "<div class='ws-sound__waveform'>"+
            //                                                                "<div class='ws-waveform'>"+
            //                                                                    "<div class='ws-waveform__layer'  data-key='ws"+id+"' data-file='Hit_Songs/"+id+".mp3' data-peaks='"+peaks+"'>"+
            //                                                                        "<wave></wave>"+
            //                                                                    "</div>"+
            //                                                                    "<div class='ws-waveform__time'>"+
            //                                                                        "<span class='ws-time ws-wave_time'></span>"+
            //                                                                        "<span class='ws-time ws-track_time'>0:30</span>"+
            //                                                                    "</div>"+
            //                                                                "</div>"+
            //                                                            "</div>"+
            //                                                        "</div>"+
            //                                                    "</div>"+
            //                                                "</div>"+
            //                                            "</div>"+
            //                                        "</div>";
            //    }
            //    createDivMySong.InnerHtml += "</div><div class='ws-soundCompactList'></div></div>";

            //    //createDivMySong.InnerHtml += "";
            //    body_content.Controls.Add(createDivMySong);
            //}

        }
        


        [WebMethod]
        public static string updateWaves(string songId,string peaks)
        {
            DBConnection DBUtils = new DBConnection();
            DataTable dt = new DataTable();
            string sql2 = "insert into song_peaks('songId,peaks') values('" + songId + "','" + peaks + "') ";
            DBUtils.ExecuteQuery(sql2);
            return sql2;
        }

        [WebMethod]
        public static string saveWaves(string userId)
        {
             DBConnection DBUtils = new DBConnection();
            DataTable dt = new DataTable();
            string sql2 = "SELECT  top 2 * FROM mpm_Songs WHERE mpm_Songs.uploader='" + userId + "' and mpm_Songs.status!=10    order by mpm_Songs.CreateDate desc";
            dt = DBUtils.ExecuteQuery(sql2);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        
    }
}