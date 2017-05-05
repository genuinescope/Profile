using SongCatalog.MPM.Data;
using SongCatelogApp.MPM_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SongCatelogApp
{
    public partial class profile6 : System.Web.UI.Page
    {
        public DBConnection DBUtils = new DBConnection();

        [System.Web.Services.WebMethod]
        public static string loadMoreSongsFeatured(string nextPage)
        {
            StringBuilder sbSongs = new StringBuilder();

            try
            {
                string userId = "5";
                ProfileServices pf = new ProfileServices();
                //get news
                DataTable songsList = pf.getSongsListFeatured(userId, nextPage);

                for (int i = 0; i < songsList.Rows.Count; i++)
                {
                    sbSongs.Append("<div class='ws-soundList__item ws-have-cover' data-id='f1_" + songsList.Rows[i]["id"] + "'>");
                    sbSongs.Append("<div role='group' class='ws-sound'>");
                    sbSongs.Append("<div class='ws-sound__body'>");
                    sbSongs.Append("<div class='ws-sound__artwork'>");
                    sbSongs.Append("<a class='ws-sound__coverArt' data-cover='background-image: url(&quotProfile_Image/" + songsList.Rows[i]["uploader"] + ".jpg&quot;);'>");
                    sbSongs.Append("<span class='ws-image ws-artwork ws-artwork-placeholder'>");
                    sbSongs.Append("<span style='background-image: url(&quotProfile_Image/" + songsList.Rows[i]["uploader"] + ".jpg&quot;);' class='ws-artwork ws-image__thumb'></span>");
                    sbSongs.Append("</span>");
                    sbSongs.Append("</a>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("<div class='ws-sound__content'>");
                    sbSongs.Append("<div class='ws-visualSound__wrapper '>");
                    sbSongs.Append("<div class='ws-sound__header'>");
                    sbSongs.Append("<div class='ws-soundTitle ws-clearfix'>");
                    sbSongs.Append("<div class='ws-soundTitle__titleContainer'>");
                    sbSongs.Append("<div class='ws-soundTitle__playButton'>");
                    sbSongs.Append("<span class='ws-button ws-button-play' tabindex='0' title='Play'>Play</span>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("<div class='ws-soundTitle__titleWrapper'>");
                    sbSongs.Append("<div class='ws-soundTitle__secondary ws-type-light'></div>");
                    sbSongs.Append("<span>" + songsList.Rows[i]["songTitle"] + "</span>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("<div class='ws-sound__waveform'>");
                    sbSongs.Append("<div class='ws-waveform'>");
                    sbSongs.Append("<div class='ws-waveform__layer' data-key='wsf1_" + songsList.Rows[i]["id"] + "' data-file='http://testapp.hitlicense.com/Hit_Songs/" + songsList.Rows[i]["id"] + ".mp3' data-peaks='" + songsList.Rows[i]["peaks"] + "'>");
                    sbSongs.Append("<wave></wave>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("<div class='ws-waveform__time'>");
                    sbSongs.Append("<span class='ws-time ws-wave_time'></span>");
                    sbSongs.Append("<span class='ws-time ws-track_time'></span>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                }


                return sbSongs.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
 
        [System.Web.Services.WebMethod]
        public static string loadMoreSongs(string nextPage)
        {
            StringBuilder sbSongs = new StringBuilder();

            try
            {
                string userId = "5";
                ProfileServices pf = new ProfileServices();
                //get news
                DataTable songsList = pf.getSongsList(userId, nextPage);

                for (int i = 0; i < songsList.Rows.Count; i++)
                {
                    sbSongs.Append("<div class='ws-soundList__item ws-have-cover' data-id='s1_" + songsList.Rows[i]["id"] + "'>");
                    sbSongs.Append("<div role='group' class='ws-sound'>");
                    sbSongs.Append("<div class='ws-sound__body'>");
                    sbSongs.Append("<div class='ws-sound__artwork'>");
                    sbSongs.Append("<a class='ws-sound__coverArt' data-cover='background-image: url(&quotProfile_Image/" + songsList.Rows[i]["uploader"] + ".jpg&quot;);'>");
                    sbSongs.Append("<span class='ws-image ws-artwork ws-artwork-placeholder'>");
                    sbSongs.Append("<span style='background-image: url(&quotProfile_Image/" + songsList.Rows[i]["uploader"] + ".jpg&quot;);' class='ws-artwork ws-image__thumb'></span>");
                    sbSongs.Append("</span>");
                    sbSongs.Append("</a>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("<div class='ws-sound__content'>");
                    sbSongs.Append("<div class='ws-visualSound__wrapper '>");
                    sbSongs.Append("<div class='ws-sound__header'>");
                    sbSongs.Append("<div class='ws-soundTitle ws-clearfix'>");
                    sbSongs.Append("<div class='ws-soundTitle__titleContainer'>");
                    sbSongs.Append("<div class='ws-soundTitle__playButton'>");
                    sbSongs.Append("<span class='ws-button ws-button-play' tabindex='0' title='Play'>Play</span>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("<div class='ws-soundTitle__titleWrapper'>");
                    sbSongs.Append("<div class='ws-soundTitle__secondary ws-type-light'></div>");
                    sbSongs.Append("<span>" + songsList.Rows[i]["songTitle"] + "</span>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("<div class='ws-sound__waveform'>");
                    sbSongs.Append("<div class='ws-waveform'>");
                    sbSongs.Append("<div class='ws-waveform__layer' data-key='wss1_" + songsList.Rows[i]["id"] + "' data-file='http://testapp.hitlicense.com/Hit_Songs/" + songsList.Rows[i]["id"] + ".mp3' data-peaks='" + songsList.Rows[i]["peaks"] + "'>");
                    sbSongs.Append("<wave></wave>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("<div class='ws-waveform__time'>");
                    sbSongs.Append("<span class='ws-time ws-wave_time'></span>");
                    sbSongs.Append("<span class='ws-time ws-track_time'></span>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                    sbSongs.Append("</div>");
                }

              
                return sbSongs.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

         
    }

        protected void linkPlaylists_Click(object sender, EventArgs e)
        {
            Control spanNext = FindControl("spanNext");
            spanNext.Visible = false;
            hdnloadtype.Value = "playlists";
            ProfileServices pf = new ProfileServices();
            DataTable plLists = pf.getAllPlaylists("5");
            StringBuilder playlists = new StringBuilder();

            for (int i = 0; i < plLists.Rows.Count; i++)
            {
                string img="default.jpg";
                if (plLists.Rows[i]["AlbumImage"].ToString() != "" && plLists.Rows[i]["AlbumImage"].ToString() != "NULL")
                {
                    img = plLists.Rows[i]["AlbumImage"].ToString();
                }

                playlists.Append("<div style='margin-left:10px;'><img src='http://testapp.hitlicense.com//Profile_AlbumImage/" + img + "' width='150' height='150'>" + plLists.Rows[i]["AlbumName"].ToString() + "</div>");
            }

            soundList.InnerHtml = playlists.ToString();


        }

        protected void linkFeatured_Click(object sender, EventArgs e)
        {
            Control spanNext = FindControl("spanNext");

            spanNext.Visible = true;
            hdnloadtype.Value = "featured";
            DataTable songsList = this.FetchDataFeatured("5", 1, 5);
            StringBuilder sbSongs = new StringBuilder();
            if (songsList.Rows.Count > 0)
            {

                spanNext.Visible = true;
            }
            else
            {
                spanNext.Visible = false;
            }
            for (int i = 0; i < songsList.Rows.Count; i++)
            {
                sbSongs.Append("<div class='ws-soundList__item ws-have-cover' data-id='f1_" + songsList.Rows[i]["id"] + "'>");
                sbSongs.Append("<div role='group' class='ws-sound'>");
                sbSongs.Append("<div class='ws-sound__body'>");
                sbSongs.Append("<div class='ws-sound__artwork'>");
                sbSongs.Append("<a class='ws-sound__coverArt' data-cover='background-image: url(&quotProfile_Image/" + songsList.Rows[i]["uploader"] + ".jpg&quot;);'>");
                sbSongs.Append("<span class='ws-image ws-artwork ws-artwork-placeholder'>");
                sbSongs.Append("<span style='background-image: url(&quotProfile_Image/" + songsList.Rows[i]["uploader"] + ".jpg&quot;);' class='ws-artwork ws-image__thumb'></span>");
                sbSongs.Append("</span>");
                sbSongs.Append("</a>");
                sbSongs.Append("</div>");
                sbSongs.Append("<div class='ws-sound__content'>");
                sbSongs.Append("<div class='ws-visualSound__wrapper '>");
                sbSongs.Append("<div class='ws-sound__header'>");
                sbSongs.Append("<div class='ws-soundTitle ws-clearfix'>");
                sbSongs.Append("<div class='ws-soundTitle__titleContainer'>");
                sbSongs.Append("<div class='ws-soundTitle__playButton'>");
                sbSongs.Append("<span class='ws-button ws-button-play' tabindex='0' title='Play'>Play</span>");
                sbSongs.Append("</div>");
                sbSongs.Append("<div class='ws-soundTitle__titleWrapper'>");
                sbSongs.Append("<div class='ws-soundTitle__secondary ws-type-light'></div>");
                sbSongs.Append("<span>" + songsList.Rows[i]["songTitle"] + "</span>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("<div class='ws-sound__waveform'>");
                sbSongs.Append("<div class='ws-waveform'>");
                sbSongs.Append("<div class='ws-waveform__layer' data-key='wsf1_" + songsList.Rows[i]["id"] + "' data-file='http://testapp.hitlicense.com/Hit_Songs/" + songsList.Rows[i]["id"] + ".mp3' data-peaks='" + songsList.Rows[i]["peaks"] + "'>");
                sbSongs.Append("<wave></wave>");
                sbSongs.Append("</div>");
                sbSongs.Append("<div class='ws-waveform__time'>");
                sbSongs.Append("<span class='ws-time ws-wave_time'></span>");
                sbSongs.Append("<span class='ws-time ws-track_time'></span>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
            }

            soundList.InnerHtml = sbSongs.ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("<script language='javascript' type='text/javascript'>");
            sb.Append("Sys.Application.add_load(func);");
            sb.Append("function func() {");
            sb.Append("Sys.Application.remove_load(func);");
            sb.Append("     var fileref = document.createElement('link');" +
"fileref.rel = 'stylesheet';" +
"fileref.type = 'text/css';" +
"fileref.href = 'css/wavesurfer.css';" +
"document.getElementsByTagName('head')[0].appendChild(fileref);       $.when(" +
      "$.getScript('js/jquery.js?ver=1.12.4')," +
      "$.getScript('wavesurfer3/wavesurfer.min.js?ver=1.2.8')," +
      "$.getScript('wavesurfer3/wavesurfer.js?ver=1.7')," +
      "$.Deferred(function (deferred) {" +
          "$(deferred.resolve);" +
      "})" +
  ").done(function () {" +
  "    (function ($) {" +
          "var settings = { 'compact_list': '0', 'color1': 'a30283', 'ID': 80, 'nonce': '08187fd71d', 'url': '', 'moduleUrl': '' };" +
          "$('#GmediaGallery_80').gmWaveSurfer(settings);" +
      "})(jQuery);" +
      "document.getElementById('spanNext').style.display = 'block';" +
  "});");
            sb.Append("}");
            sb.Append("</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "script", sb.ToString(), false);
        }

        protected void linkAllSongs_Click(object sender, EventArgs e)
        {
           
           
            DataTable songsList = this.FetchData("5", 1, 5);
            StringBuilder sbSongs = new StringBuilder();
            Control spanNext = FindControl("spanNext");
           
            if (songsList.Rows.Count > 0)
            {

                spanNext.Visible = true;
            }
            else
            {
                spanNext.Visible = false;
            }
            for (int i = 0; i < songsList.Rows.Count; i++)
            {
                sbSongs.Append("<div class='ws-soundList__item ws-have-cover' data-id='s1_" + songsList.Rows[i]["id"] + "'>");
                sbSongs.Append("<div role='group' class='ws-sound'>");
                sbSongs.Append("<div class='ws-sound__body'>");
                sbSongs.Append("<div class='ws-sound__artwork'>");
                sbSongs.Append("<a class='ws-sound__coverArt' data-cover='background-image: url(&quotProfile_Image/" + songsList.Rows[i]["uploader"] + ".jpg&quot;);'>");
                sbSongs.Append("<span class='ws-image ws-artwork ws-artwork-placeholder'>");
                sbSongs.Append("<span style='background-image: url(&quotProfile_Image/" + songsList.Rows[i]["uploader"] + ".jpg&quot;);' class='ws-artwork ws-image__thumb'></span>");
                sbSongs.Append("</span>");
                sbSongs.Append("</a>");
                sbSongs.Append("</div>");
                sbSongs.Append("<div class='ws-sound__content'>");
                sbSongs.Append("<div class='ws-visualSound__wrapper '>");
                sbSongs.Append("<div class='ws-sound__header'>");
                sbSongs.Append("<div class='ws-soundTitle ws-clearfix'>");
                sbSongs.Append("<div class='ws-soundTitle__titleContainer'>");
                sbSongs.Append("<div class='ws-soundTitle__playButton'>");
                sbSongs.Append("<span class='ws-button ws-button-play' tabindex='0' title='Play'>Play</span>");
                sbSongs.Append("</div>");
                sbSongs.Append("<div class='ws-soundTitle__titleWrapper'>");
                sbSongs.Append("<div class='ws-soundTitle__secondary ws-type-light'></div>");
                sbSongs.Append("<span>" + songsList.Rows[i]["songTitle"] + "</span>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("<div class='ws-sound__waveform'>");
                sbSongs.Append("<div class='ws-waveform'>");
                sbSongs.Append("<div class='ws-waveform__layer' data-key='wss1_" + songsList.Rows[i]["id"] + "' data-file='http://testapp.hitlicense.com/Hit_Songs/" + songsList.Rows[i]["id"] + ".mp3' data-peaks='" + songsList.Rows[i]["peaks"] + "'>");
                sbSongs.Append("<wave></wave>");
                sbSongs.Append("</div>");
                sbSongs.Append("<div class='ws-waveform__time'>");
                sbSongs.Append("<span class='ws-time ws-wave_time'></span>");
                sbSongs.Append("<span class='ws-time ws-track_time'></span>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
                sbSongs.Append("</div>");
            }

            soundList.InnerHtml = sbSongs.ToString();


            StringBuilder sb = new StringBuilder();
            sb.Append("<script language='javascript' type='text/javascript'>");
            sb.Append("Sys.Application.add_load(func);");
            sb.Append("function func() {");
            sb.Append("Sys.Application.remove_load(func);");
            sb.Append("     var fileref = document.createElement('link');"+
"fileref.rel = 'stylesheet';"+
"fileref.type = 'text/css';"+
"fileref.href = 'css/wavesurfer.css';"+
"document.getElementsByTagName('head')[0].appendChild(fileref);       $.when("+
      "$.getScript('js/jquery.js?ver=1.12.4'),"+
      "$.getScript('wavesurfer3/wavesurfer.min.js?ver=1.2.8'),"+
      "$.getScript('wavesurfer3/wavesurfer.js?ver=1.7'),"+
      "$.Deferred(function (deferred) {"+
          "$(deferred.resolve);"+
      "})"+
  ").done(function () {"+
  "    (function ($) {"+
          "var settings = { 'compact_list': '0', 'color1': 'a30283', 'ID': 80, 'nonce': '08187fd71d', 'url': '', 'moduleUrl': '' };"+
          "$('#GmediaGallery_80').gmWaveSurfer(settings);"+
      "})(jQuery);"+
      "document.getElementById('spanNext').style.display = 'block';"+
  "});");
            sb.Append("}");
            sb.Append("</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "script", sb.ToString(), false);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {
                  
                    ProfileServices pf = new ProfileServices();
                    //string userId = "5";
                    string userId = Request.QueryString["userId"].ToString();
                    imgCover.ImageUrl = "http://testapp.hitlicense.com/Profile_CoverPhoto/" + userId + "_Cover.jpg";
                    imgProfile.ImageUrl = "http://testapp.hitlicense.com/Profile_UserImage/" + userId + "_user.jpg";

                    Control spanNext = FindControl("spanNext");
                    DataTable songsList = this.FetchData(userId,1,5);
                    StringBuilder sbSongs = new StringBuilder();
                    if (songsList.Rows.Count > 0)
                    {
                        
                        spanNext.Visible = true;
                    }
                    else {
                        spanNext.Visible = false;
                    }
                    for (int i = 0; i < songsList.Rows.Count;i++ )
                    {
                          sbSongs.Append("<div class='ws-soundList__item ws-have-cover' data-id='s1_"+songsList.Rows[i]["id"]+"'>");
                          sbSongs.Append("<div role='group' class='ws-sound'>");
                          sbSongs.Append("<div class='ws-sound__body'>");
                          sbSongs.Append("<div class='ws-sound__artwork'>");
                          sbSongs.Append("<a class='ws-sound__coverArt' data-cover='background-image: url(&quotProfile_Image/"+songsList.Rows[i]["uploader"]+".jpg&quot;);'>");
                          sbSongs.Append("<span class='ws-image ws-artwork ws-artwork-placeholder'>");
                          sbSongs.Append("<span style='background-image: url(&quotProfile_Image/" + songsList.Rows[i]["uploader"] + ".jpg&quot;);' class='ws-artwork ws-image__thumb'></span>");
                          sbSongs.Append("</span>");
                          sbSongs.Append("</a>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("<div class='ws-sound__content'>");
                          sbSongs.Append("<div class='ws-visualSound__wrapper '>");
                          sbSongs.Append("<div class='ws-sound__header'>");
                          sbSongs.Append("<div class='ws-soundTitle ws-clearfix'>");
                          sbSongs.Append("<div class='ws-soundTitle__titleContainer'>");
                          sbSongs.Append("<div class='ws-soundTitle__playButton'>");
                          sbSongs.Append("<span class='ws-button ws-button-play' tabindex='0' title='Play'>Play</span>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("<div class='ws-soundTitle__titleWrapper'>");
                          sbSongs.Append("<div class='ws-soundTitle__secondary ws-type-light'></div>");
                          sbSongs.Append("<span>" + songsList.Rows[i]["songTitle"] + "</span>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("<div class='ws-sound__waveform'>");
                          sbSongs.Append("<div class='ws-waveform'>");
                          sbSongs.Append("<div class='ws-waveform__layer' data-key='wss1_" + songsList.Rows[i]["id"] + "' data-file='http://testapp.hitlicense.com/Hit_Songs/" + songsList.Rows[i]["id"] + ".mp3' data-peaks='" + songsList.Rows[i]["peaks"] + "'>");
                          sbSongs.Append("<wave></wave>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("<div class='ws-waveform__time'>");
                          sbSongs.Append("<span class='ws-time ws-wave_time'></span>");
                          sbSongs.Append("<span class='ws-time ws-track_time'></span>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("</div>");
                          sbSongs.Append("</div>");
                    }

                    soundList.InnerHtml = sbSongs.ToString();


                    //right bar
                    DataTable dtProfileInfo = pf.getProfileInfo(userId);
                    if (dtProfileInfo.Rows.Count > 0)
                    {
                        lnkWebsite.NavigateUrl = dtProfileInfo.Rows[0]["webSite"].ToString();
                        lnkWebsite.Text = dtProfileInfo.Rows[0]["webSite"].ToString();
                        lnkFacebook.NavigateUrl = dtProfileInfo.Rows[0]["FBLink"].ToString();
                        lnkFacebook.Text = dtProfileInfo.Rows[0]["FBLink"].ToString();
                        lnkTwitter.NavigateUrl = dtProfileInfo.Rows[0]["Tiwitter"].ToString();
                        lnkTwitter.Text = dtProfileInfo.Rows[0]["Tiwitter"].ToString();

                        lblPro.Text = dtProfileInfo.Rows[0]["Pro"].ToString();
                        lblOrg.Text = dtProfileInfo.Rows[0]["Organization"].ToString();
                        lblJoined.Text = Convert.ToDateTime(dtProfileInfo.Rows[0]["createDate"].ToString()).ToString("MMMM yyyy");
                        if (dtProfileInfo.Rows[0]["BIO"].ToString().Length > 100)
                        {
                            lblBio.Text = (dtProfileInfo.Rows[0]["BIO"].ToString()).Substring(0, 100);
                            bioMore.Visible = true;
                        }

                        lbluploader.Text = dtProfileInfo.Rows[0]["ScreenName"].ToString();
                        lblemail.Text = dtProfileInfo.Rows[0]["email"].ToString();
                        lblcountry.Text = dtProfileInfo.Rows[0]["addrCity"].ToString() + "," + dtProfileInfo.Rows[0]["addrCountry"].ToString();
                    }

                    StringBuilder sbPhotosVideos = new StringBuilder();
                    DataTable dtVP = pf.getVideos(userId);
                    if (dtVP.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtVP.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                sbPhotosVideos.Append("<div class='item active'>");
                            }
                            else
                            {
                                sbPhotosVideos.Append("<div class='item'>");
                            }

                            sbPhotosVideos.Append("<div class='col-md-4 video-1'>");
                            sbPhotosVideos.Append("<iframe width='100%' src='");
                            sbPhotosVideos.Append(dtVP.Rows[i]["FileUrl"]);
                            sbPhotosVideos.Append("' frameborder='0' allowfullscreen></iframe>");
                            sbPhotosVideos.Append("</div>");
                            sbPhotosVideos.Append("</div>");

                        }

                        videosPhotos.InnerHtml = sbPhotosVideos.ToString();

                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                    //Response.Redirect("../Default.aspx");
                }

            }
            else
            {


   
            }

        }

        public void refeed_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            HiddenField hSongID = (HiddenField)e.Item.FindControl("hSongID");

            //string path = @"http://testapp.hitlicense.com/Hit_Songs/" + hSongID.Value + ".mp3";


        }

        private DataTable SongTable
        {
            get { return (DataTable)ViewState["SongTable"]; }
            set { ViewState["SongTable"] = value; }
        }

        private DataTable FetchDataFeatured(string userId, int nstartIndex, int pageSize)
        {
            string sql = "SELECT * from  (SELECT *,ROW_NUMBER()  OVER(ORDER BY id )  AS RowRank " +
                           " from Songs Where status<>10 and uploader='" + userId + "' AND Featured=1 AND AddtoProfile='Y') AS songtable " +
                           "  left join song_peaks on songtable.id = song_peaks.songId  where RowRank between " + nstartIndex + " and " + (pageSize);

            DataTable dt = DBUtils.ExecuteQuery(sql);
            dt = DBUtils.ExecuteQuery(sql);
            //this.SongTable = dt;
            return dt;

        }

        private DataTable FetchData(string userId,int nstartIndex, int pageSize)
        {
            string sql = "SELECT * from  (SELECT *,ROW_NUMBER()  OVER(ORDER BY id )  AS RowRank " +
                           " from Songs Where status<>10 and uploader='" + userId + "' AND AddtoProfile='Y') AS songtable " +
                           "  left join song_peaks on songtable.id = song_peaks.songId  where RowRank between " + nstartIndex + " and " + (pageSize);

            DataTable dt = DBUtils.ExecuteQuery(sql);
                dt = DBUtils.ExecuteQuery(sql);
                //this.SongTable = dt;
                return dt;

        }
        [System.Web.Services.WebMethod]
        public static string bioLoadMore()
        {
            ProfileServices pf = new ProfileServices();
            string userId = "5";
            DataTable dtProfileInfo = pf.getProfileInfo(userId);
            return dtProfileInfo.Rows[0]["BIO"].ToString();

        }

        [System.Web.Services.WebMethod]
        public static string loadMoreCredits(string nextPage)
        {
            StringBuilder sbNews = new StringBuilder();
            try
            {

                string userId = "5";
                ProfileServices pf = new ProfileServices();
                //get news
                DataTable dtNews = pf.getProfileCredits(userId, nextPage);
                if (dtNews.Rows.Count > 0)
                {

                    for (int i = 0; i < dtNews.Rows.Count; i++)
                    {
                        sbNews.Append("<tr>");
                        sbNews.Append("<td>");
                        sbNews.Append(dtNews.Rows[i]["CreditLine1"]);
                        sbNews.Append("</td>");
                        sbNews.Append("<td>");
                        sbNews.Append(dtNews.Rows[i]["CreditLine2"]);
                        sbNews.Append("</td>");
                        sbNews.Append("<td>");
                        sbNews.Append(dtNews.Rows[i]["CreditLine3"]);
                        sbNews.Append("</td>");
                        sbNews.Append("</tr>");

                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sbNews.ToString();
        }

        [System.Web.Services.WebMethod]
        public static string loadMoreAwards(string nextPage)
        {
            StringBuilder sbNews = new StringBuilder();
            try
            {

                string userId = "5";
                ProfileServices pf = new ProfileServices();
                //get news
                DataTable dtNews = pf.getProfileAwards(userId, nextPage);
                if (dtNews.Rows.Count > 0)
                {
                    for (int i = 0; i < dtNews.Rows.Count; i++)
                    {
                        sbNews.Append("<div class='news-item'>");
                        sbNews.Append("<div class='news-image'>");
                        sbNews.Append("<img src='http://testapp.hitlicense.com//Profile_AwardImages/" + dtNews.Rows[i]["AwardID"].ToString() + ".jpg'  width='100' height='100'>");
                        sbNews.Append("</div>");
                        sbNews.Append("<div class='news-desc'>");
                        sbNews.Append("<h5>");
                        sbNews.Append(dtNews.Rows[i]["AwardTitle"]);
                        sbNews.Append("</h5>");
                        sbNews.Append("<p>");
                        sbNews.Append(dtNews.Rows[i]["Award"]);
                        sbNews.Append("</p>");
                        sbNews.Append("</div>");
                        sbNews.Append("<span>");
                        sbNews.Append(dtNews.Rows[i]["CreatDateTime"]);
                        sbNews.Append("</span>");
                        sbNews.Append("</div>");

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sbNews.ToString();
        }


        [System.Web.Services.WebMethod]
        public static string loadMoreReviews(string nextPage)
        {
            StringBuilder sbNews = new StringBuilder();
            try
            {

                string userId = "5";
                ProfileServices pf = new ProfileServices();
                //get news
                DataTable dtNews = pf.getProfileReviews(userId, nextPage);
                if (dtNews.Rows.Count > 0)
                {
                    for (int i = 0; i < dtNews.Rows.Count; i++)
                    {
                        sbNews.Append("<div class='news-item'>");
                        sbNews.Append("<div class='news-image'>");
                        sbNews.Append("<img src='../images/news/n1.png'>");
                        sbNews.Append("</div>");
                        sbNews.Append("<div class='news-desc'>");
                        sbNews.Append("<h5>");
                        sbNews.Append(dtNews.Rows[i]["WriteBy"]);
                        sbNews.Append("</h5>");
                        sbNews.Append("<p>");
                        sbNews.Append(dtNews.Rows[i]["Review"]);
                        sbNews.Append("</p>");
                        sbNews.Append("</div>");
                        sbNews.Append("<span>");
                        sbNews.Append(dtNews.Rows[i]["Institute"]);
                        sbNews.Append("</span>");
                        sbNews.Append("</div>");

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sbNews.ToString();
        }

        [System.Web.Services.WebMethod]
        public static string loadMoreNews(string nextPage)
        {
            StringBuilder sbNews = new StringBuilder();
            try
            {

                string userId = "5";
                ProfileServices pf = new ProfileServices();
                //get news
                DataTable dtNews = pf.getProfileNews(userId, nextPage);
                if (dtNews.Rows.Count > 0)
                {
                    for (int i = 0; i < dtNews.Rows.Count; i++)
                    {
                        sbNews.Append("<div class='news-item'>");
                        sbNews.Append("<div class='news-image'>");
                        sbNews.Append("<img src='http://testapp.hitlicense.com//Profile_NewsImages//" + dtNews.Rows[i]["NewsID"].ToString() + ".jpg' width='100' height='100'>");
                        sbNews.Append("</div>");
                        sbNews.Append("<div class='news-desc'>");
                        sbNews.Append("<h5>");
                        sbNews.Append(dtNews.Rows[i]["NewsTitle"]);
                        sbNews.Append("</h5>");
                        sbNews.Append("<p>");
                        sbNews.Append(dtNews.Rows[i]["NewsDescription"]);
                        sbNews.Append("</p>");
                        sbNews.Append("</div>");
                        sbNews.Append("<span>");
                        sbNews.Append(dtNews.Rows[i]["PublishDate"]);
                        sbNews.Append("</span>");
                        sbNews.Append("</div>");

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sbNews.ToString();
        }

        [System.Web.Services.WebMethod]
        public static string loadVideosPhotos()
        {
            StringBuilder sbNews = new StringBuilder();
            try
            {

                string userId = "5";
                ProfileServices pf = new ProfileServices();
                DataTable dtVP = pf.getVideos(userId);
                if (dtVP.Rows.Count > 0)
                {
                    for (int i = 0; i < dtVP.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            sbNews.Append("<div class='item active'>");
                        }
                        else
                        {
                            sbNews.Append("<div class='item'>");
                        }

                        sbNews.Append("<div class='col-md-4 video-1'>");
                        sbNews.Append("<iframe width='100%' src='");
                        sbNews.Append(dtVP.Rows[i]["FileUrl"]);
                        sbNews.Append("' frameborder='0' allowfullscreen></iframe>");
                        sbNews.Append("</div>");
                        sbNews.Append("</div>");

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sbNews.ToString();
        }

        

    }
}