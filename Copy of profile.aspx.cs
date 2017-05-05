using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;


namespace SongCatelogApp
{
    public partial class profile : System.Web.UI.Page
    {
        public DBConnection DBUtils = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //get user profile details
                //char[] delimiterChars = {'/'};
                //String originalPath = new Uri(HttpContext.Current.Request.Url.AbsoluteUri).OriginalString;
                //string[] parameters = originalPath.Split(delimiterChars);
                //string user_id = parameters[6].ToString();
                int i=0;
                DataTable dt = new DataTable();
                string userId = "10394";
                string sql = "SELECT * from mpm_Users where id=10394";
                DataTable dtt = DBUtils.ExecuteQuery(sql);
                string weburl = System.Configuration.ConfigurationManager.ConnectionStrings["WebURL"].ConnectionString;

                //ProfilePic.ImageUrl = weburl + "Profile_Image/" + userId + ".jpg";
                ProfilePic.ImageUrl = "http://app.hitlicense.com/Profile_Image/" + userId + ".jpg";
            
                txtName.Text = dtt.Rows[0]["name"].ToString();
                txtEmail.Text = dtt.Rows[0]["email"].ToString();
                txtPhone.Text = dtt.Rows[0]["phone"].ToString();

                System.Web.UI.HtmlControls.HtmlGenericControl createDivMySong = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                //createDivMySong.InnerHtml += "        <script>"+
            //"jQuery(document).ready(function($) { var settings_ap = { disable_volume: 'off' , disable_scrub: 'default'                    , design_skin: 'skin-wave'                    , skinwave_dynamicwaves: 'off'                    , skinwave_enableSpectrum: 'off'                    , settings_backup_type: 'full'                    , skinwave_enableReflect: 'on'                    , skinwave_comments_enable: 'on'                };                dzsag_init('#ag1', {                    'transition': 'fade'                    , 'autoplay': 'on'                    , 'autoplayNext': 'on'                    , design_menu_position: 'bottom'                    , 'settings_ap': settings_ap                    , design_menu_state: 'closed'                    , design_menu_show_player_state_button: 'on'                });            });        </script>";

                string sql2 = "SELECT * FROM mpm_Songs WHERE uploader='10394' and id>63000 and status!=10 order by CreateDate desc";
                dt = this.DBUtils.ExecuteQuery(sql2);

                //createDivMySong.InnerHtml += "<div id='ag1' class='audiogallery skin-default' style='opacity:0; margin-top: 70px;'><div class='items'>";
                createDivMySong.InnerHtml += "    <div id='ag1' class='audiogallery' style='opacity:0; margin-top: 70px;'>"+
                            "<div class='items'>";
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string songtitle = dt.Rows[i][1].ToString();
                    string artist = dt.Rows[i][2].ToString();
                    createDivMySong.InnerHtml += "<div class='audioplayer-tobe' style='width:100%; ' data-thumb='img/thumb3.jpg' data-scrubbg='http://app.hitlicense.com/WaveForms/" + id + "_scrubbg.png'  data-scrubprog='http://app.hitlicense.com/WaveForms/"+id+"_scrubprog.png'  data-type='normal' data-source='http://app.hitlicense.com/Hit_Songs/" + id + ".mp3'>" +
                                    "<div class='meta-artist'><span class='the-artist'>" + songtitle + "</span><br/><span class='the-name'>Revenge</span>" +
                                    "</div>"+
                                    "<div class='menu-description'>"+
                                        "<div class='menu-item-thumb-con'><div class='menu-item-thumb' style='background-image: url(http://app.hitlicense.com/WaveForms/" + id + "_scrubbg.png)'></div></div>" +
                                        //"<span class='the-artist'>" + artist + "</span>" +
                                        "<span class='the-name'>"+songtitle+"</span>"+
                                    "</div>"+
                                "</div>";
                }
                         
          createDivMySong.InnerHtml += " </div>"+
                        "</div>";
                  
                //createDivMySong.InnerHtml += "";
                body_content.Controls.Add(createDivMySong);
                //get songslist of this user and default album
                //body_content.InnerHtml = createDivMySong;
                
                //divBody.InnerHtml = "aaaaaaaaaaaaaa";

            }
        }
    }
}