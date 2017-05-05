using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SongCatelogApp.MPM_Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Net;

namespace SongCatelogApp
{
    public partial class profile_test : System.Web.UI.Page
    {
        public DBConnection DBUtils = new DBConnection();

        protected bool checkIfImgAvailable(string imgPath)
        {

            HttpWebResponse response = null;
            var request = (HttpWebRequest)WebRequest.Create(imgPath);
            request.Method = "HEAD";
            bool checkAval = false;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                checkAval = true;
            }
            catch (WebException ex)
            {

                /* A WebException will be thrown if the status of the response is not `200 OK` */
            }
            return checkAval;
        }


        protected void loadPersonalInfo()
        {
            EmptyCover.Visible = false;
            //sociallinks.Visible = false;
            //  string userId = Request.QueryString["userID"].ToString();
            morenews.Visible = false;
            MoreAwards.Visible = false;
            moreReviews.Visible = false;
            morecredits.Visible = false;

            ProfileServices pf = new ProfileServices();
            string userId = Session["userId"].ToString();

            //get artist types
            DataTable dtt = pf.getArtistTypes(userId);
            string artTypes = "";
            for (int t = 0; t < dtt.Rows.Count; t++)
            {
                artTypes += dtt.Rows[t]["ArtistType"].ToString() + ", ";
            }
            if (artTypes.Length >= 2)
            {
                artTypes = artTypes.Remove(artTypes.Length - 2);
            }

            lblArtistTypes.Text = artTypes;

            DataTable dtu = pf.getPersonalInfo(userId);



            if (dtu.Rows.Count > 0)
            {

                lbluploader.Text = dtu.Rows[0]["ProfessionalName"].ToString();
                //lblemail.Text = dtu.Rows[0]["email"].ToString();
                lblcity.Text = dtu.Rows[0]["City"].ToString() + " " + dtu.Rows[0]["Province"].ToString();
                lblCountry.Text = dtu.Rows[0]["CountryName"].ToString();
                id_flag.Attributes.Add("src", "http://app.hitlicense.com/flags/" + dtu.Rows[0]["Country"].ToString() + ".png");

                string profileImg = profileImgpath(userId, dtu.Rows[0]["FileExtension"].ToString());

                imgProfile.Attributes.Add("src", profileImg);
                string coverImg = "http://app.hitlicense.com/Profile_CoverPhoto/" + dtu.Rows[0]["UserID"].ToString() + "_Cover.jpg";
                if (checkIfImgAvailable(coverImg))
                {

                    imgCover.Attributes.Add("src", "http://app.hitlicense.com/Profile_CoverPhoto/" + dtu.Rows[0]["UserID"].ToString() + "_Cover.jpg");
                    //lblJoined.Text = Convert.ToDateTime(dtu.Rows[0]["JoineDate"].ToString()).ToString("MMMM yyyy");
                }
                else
                {
                    EmptyCover.Visible = true;
                    imgCover.Visible = false;
                }

                pweb.Visible = false;
                pfb.Visible = false;
                pt.Visible = false;
                plink.Visible = false;
                psc.Visible = false;
                pins.Visible = false;
                pyout.Visible = false;

                if (dtu.Rows[0]["webSite"].ToString() != "")
                {
                    lnkWebsite.NavigateUrl = (dtu.Rows[0]["webSite"].ToString().Contains("http://") || dtu.Rows[0]["webSite"].ToString().Contains("https://")) == true ? dtu.Rows[0]["webSite"].ToString() : "http://" + dtu.Rows[0]["webSite"].ToString();
                    //lnkWebsite.Text = "Personal Web";
                    pweb.Visible = true;
                    //sociallinks.Visible = true;
                }

                if (dtu.Rows[0]["FBLink"].ToString() != "")
                {
                    lnkFacebook.NavigateUrl = (dtu.Rows[0]["FBLink"].ToString().Contains("http://") || dtu.Rows[0]["FBLink"].ToString().Contains("https://")) == true ? dtu.Rows[0]["FBLink"].ToString() : "http://" + dtu.Rows[0]["FBLink"].ToString();
                    // lnkFacebook.Text = "Facebook";
                    pfb.Visible = true;
                    //sociallinks.Visible = true;
                }
                if (dtu.Rows[0]["Instagram"].ToString() != "")
                {
                    lnkInstagram.NavigateUrl = (dtu.Rows[0]["Instagram"].ToString().Contains("http://") || dtu.Rows[0]["Instagram"].ToString().Contains("https://")) == true ? dtu.Rows[0]["Instagram"].ToString() : "http://" + dtu.Rows[0]["Instagram"].ToString();
                    // lnkFacebook.Text = "Facebook";
                    pins.Visible = true;
                    //sociallinks.Visible = true;
                }
                if (dtu.Rows[0]["Tiwitter"].ToString() != "")
                {
                    lnkTwitter.NavigateUrl = (dtu.Rows[0]["Tiwitter"].ToString().Contains("http://") || dtu.Rows[0]["Tiwitter"].ToString().Contains("https://")) == true ? dtu.Rows[0]["Tiwitter"].ToString() : "http://" + dtu.Rows[0]["Tiwitter"].ToString();
                    // lnkTwitter.Text = "Twitter";
                    pt.Visible = true;
                    //sociallinks.Visible = true;
                }

                if (dtu.Rows[0]["LinkdIn"].ToString() != "")
                {
                    lnkLinked.NavigateUrl = (dtu.Rows[0]["LinkdIn"].ToString().Contains("http://") || dtu.Rows[0]["LinkdIn"].ToString().Contains("https://")) == true ? dtu.Rows[0]["LinkdIn"].ToString() : "http://" + dtu.Rows[0]["LinkdIn"].ToString();
                    // lnkLinked.Text = "LinkedIn";
                    plink.Visible = true;
                    //sociallinks.Visible = true;
                }

                if (dtu.Rows[0]["SC"].ToString() != "")
                {
                    lblSC.NavigateUrl = (dtu.Rows[0]["SC"].ToString().Contains("http://") || dtu.Rows[0]["SC"].ToString().Contains("https://")) == true ? dtu.Rows[0]["SC"].ToString() : "http://" + dtu.Rows[0]["SC"].ToString();
                    // lblSC.Text = "Soundcloud";
                    psc.Visible = true;
                    //sociallinks.Visible = true;
                }
                if (dtu.Rows[0]["Youtube"].ToString() != "")
                {
                    lblyoutube.NavigateUrl = (dtu.Rows[0]["Youtube"].ToString().Contains("http://") || dtu.Rows[0]["Youtube"].ToString().Contains("https://")) == true ? dtu.Rows[0]["Youtube"].ToString() : "http://" + dtu.Rows[0]["Youtube"].ToString();
                    // lblSC.Text = "Soundcloud";
                    pyout.Visible = true;
                    //sociallinks.Visible = tdivPhotosrue;
                }

                //video photo title

                lblVideoTitle.Text = (dtu.Rows[0]["videoTitle"].ToString() != null ? dtu.Rows[0]["videoTitle"].ToString() : "");
                lblPhotoTitle.Text = (dtu.Rows[0]["photoTitle"].ToString() != null ? dtu.Rows[0]["photoTitle"].ToString() : "");

                pro.Visible = ((dtu.Rows[0]["Pro"].ToString() != null && dtu.Rows[0]["Pro"].ToString() != "") ? true : false);
                lblPro.Text = (dtu.Rows[0]["Pro"].ToString() != null ? dtu.Rows[0]["Pro"].ToString() : "");

                caeIP.Visible = ((dtu.Rows[0]["IP"].ToString() != null && dtu.Rows[0]["IP"].ToString() != "") ? true : false);
                lblCaeIP.Text = (dtu.Rows[0]["IP"].ToString() != null ? dtu.Rows[0]["IP"].ToString() : "");

                org.Visible = ((dtu.Rows[0]["Organization"].ToString() != null && dtu.Rows[0]["Organization"].ToString() != "") ? true : false);
                lblOrg.Text = (dtu.Rows[0]["Organization"].ToString() != "" ? dtu.Rows[0]["Organization"].ToString() : "");
                bio.Visible = ((dtu.Rows[0]["BIO"].ToString() != null && dtu.Rows[0]["BIO"].ToString() != "") ? true : false);

                int tabactive = 0;

                if (dtu.Rows[0]["BIO"].ToString().Length > 300)
                {
                    lblBio.Text = (dtu.Rows[0]["BIO"].ToString()).Substring(0, 300);
                    bioMore.Visible = true;
                }
                else
                {
                    lblBio.Text = dtu.Rows[0]["BIO"].ToString();
                }


                string sqlg = "SELECT * from ProfessionalInfoGenreList left join GenreDetails on GenreDetails.GenreID=ProfessionalInfoGenreList.GenreID where ProfessionalInfoGenreList.UserID=" + userId;
                DataTable dtg = DBUtils.ExecuteQuery(sqlg);
                string ugenre = "";
                if (dtg.Rows.Count > 0)
                {
                    for (int s = 0; s < dtg.Rows.Count; s++)
                    {
                        ugenre = ugenre + "<div class='divuserGen'>" + dtg.Rows[s]["Genre"] + "</div>";
                    }
                }

                //if (genre.Length > 0)
                //{
                //    genre = genre.Remove(genre.Length - 1);
                //}
                userGenre.InnerHtml = ugenre;
                string albumId = Page.RouteData.Values["albumId"].ToString();
                if (dtu.Rows[0]["News_OnOff"].ToString() == "True")
                {
                    lnkNews.Visible = true;
                    if (tabactive == 0)
                    {
                        lnkNews.Attributes.Add("class", "active");
                        i1a.Attributes.Add("class", "tab-pane active");
                        tabactive = 1;
                    }
                    loadNews(userId);
                }
                if (dtu.Rows[0]["Credits_OnOff"].ToString() == "True")
                {
                    lnkCredits.Visible = true;
                    if (tabactive == 0)
                    {
                        lnkCredits.Attributes.Add("class", "active");
                        i2a.Attributes.Add("class", "tab-pane active");
                        tabactive = 1;
                    }
                    loadCredits(userId);
                }
                if (dtu.Rows[0]["Awards_OnOff"].ToString() == "True")
                {
                    lnkAwards.Visible = true;
                    if (tabactive == 0)
                    {
                        lnkAwards.Attributes.Add("class", "active");
                        i3a.Attributes.Add("class", "tab-pane active");
                        tabactive = 1;
                    }
                    loadAwards(userId);
                }

                if (dtu.Rows[0]["Reviews_OnOff"].ToString() == "True")
                {
                    lnkReviews.Visible = true;
                    if (tabactive == 0)
                    {
                        lnkReviews.Attributes.Add("class", "active");
                        i4a.Attributes.Add("class", "tab-pane active");
                        tabactive = 1;
                    }
                    loadReviews(userId);
                }
                lblVideoTitle.Visible = false;
                lblPhotoTitle.Visible = false;
                if (dtu.Rows[0]["Video_OnOff"].ToString() == "True")
                {
                    loadVideos(userId);
                    loadPhotos(userId);
                }



            }

        }
        protected string profileImgpath(string userId, string FileExt)
        {
            string profileImg = "http://app.hitlicense.com/Profile_UserImage/" + userId + "_user.jpg";

            HttpWebResponse response = null;
            var request = (HttpWebRequest)WebRequest.Create(profileImg);
            request.Method = "HEAD";
            bool checkAval = false;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                checkAval = true;
            }
            catch (WebException ex)
            {

                /* A WebException will be thrown if the status of the response is not `200 OK` */
            }

            if (checkAval)
            {
                profileImg = "http://app.hitlicense.com/Profile_UserImage/" + userId + "_user.jpg";
            }
            else if (FileExt == "")
            {
                profileImg = "http://app.hitlicense.com/templates/images/artist/user.png";
            }
            else
            {
                profileImg = "http://app.hitlicense.com/Profile_Image/" + userId + FileExt;
            }
            return profileImg;


        }

        public string loadSongs()
        {
            int songstart = 0;
            string uid = Session["userId"].ToString();
            ProfileServices pf = new ProfileServices();
            
            StringBuilder sd = new StringBuilder();
            try
            {


                DataTable songDetails = pf.getSongsList(uid, songstart);
                if (songDetails.Rows.Count > 0)
                {
                    for (int i = 0; i < (songDetails.Rows.Count); i++)
                    {

                        string peaks = (songDetails.Rows[i]["peakVal"].ToString() != null) ? songDetails.Rows[i]["peakVal"].ToString() : "[]";
                      //  string coverArt = (System.IO.File.Exists(@"C:\\inetpub\\wwwroot\\Hitlicense\\Profile_SongImage\\" + songDetails.Rows[i]["id"].ToString() + ".jpg")) ? "http://testapp.hitlicense.com/Profile_SongImage/" + songDetails.Rows[i]["id"].ToString() + ".jpg" : ((System.IO.File.Exists(@"C:\\inetpub\\wwwroot\\Hitlicense\\Profile_UserImage\\" + songDetails.Rows[i]["uploader"].ToString() + "_user.jpg")) ? "http://testapp.hitlicense.com/Profile_UserImage/" + songDetails.Rows[i]["uploader"].ToString() + "_user.jpg" : "http:/testapp.hitlicense.com/Profile_SongImage/default_cropImg.jpg");



                        sd.Append("<div class='ws-soundList__item ws-have-cover' data-id='" + songDetails.Rows[i]["id"] + "'>" +
                                                "<div role='group' class='ws-sound'>" +
                                                    "<div class='ws-sound__body'>" +
                                                     "   <div class='ws-sound__artwork'>" +
                                                      "      <a class='ws-sound__coverArt' href='" + songDetails.Rows[i]["imgpath"].ToString() + "' data-cover='background-image: url('" + songDetails.Rows[i]["imgpath"].ToString() + "');'>" +
                                                       "        <span class='ws-image ws-artwork ws-artwork-placeholder'>" +
                                                        "            <span style='background-image: url(&quot;" + songDetails.Rows[i]["imgpath"].ToString() + "&quot;);' class='ws-artwork ws-image__thumb' aria-role='img'></span>" +
                                                               "    </span>" +
                                                         "   </a>" +
                                                        "</div>" +
                                                        "<div class='ws-sound__content'>" +
                                                         "   <div class='ws-visualSound__wrapper '>" +
                                                          "      <div class='ws-sound__header'>" +
                                                                    "   <div class='ws-soundTitle ws-clearfix'>" +
                                                                        "   <div class='ws-soundTitle__titleContainer'>" +
                                                                            "   <div class='ws-soundTitle__playButton'>" +
                                                                                "   <span class='ws-button ws-button-play' tabindex='0' title='Play'>Play</span>" +
                                                                             "  </div>" +
                                                                             "  <div class='ws-soundTitle__titleWrapper'>" +
                                                                                 "  <div class='ws-soundTitle__secondary ws-type-light'><a href='' class='ws-link-light'><span>" + songDetails.Rows[i]["songTitle"] + "</span></a></div>" +
                                                                                 "  <a class='ws-soundTitle__title ws-link-dark' href=''>" +
                                                                                   " <span>" + songDetails.Rows[i]["artist"] + "</span>" +
                                                                                "   </a>" +
                                                                             "  </div>" +
                                                                             "  <div class='ws-soundTitle__additionalContainer'>" +
                                                                                "   <div class='ws-soundTitle__tags'>&nbsp;</div>" +
                                                                                 "  <div class='ws-soundTitle__catContainer'>" +
                                                                                 "  </div>" +
                                                                             "  </div>" +
                                                                         "  </div>" +
                                                                     "  </div>" +
                                                                 "  </div>" +
                                                                 "  <div class='ws-sound__waveform'>" +
                                                                        "  <div class='ws-waveform'>" +
                                                                         "  <div class='ws-waveform__layer' data-key='ws" + songDetails.Rows[i]["id"] + "' data-file='http://testapp.hitlicense.com/Hit_Songs/" + songDetails.Rows[i]["songId"] + ".mp3' data-peaks='" + peaks + "'>" +
                                                                          "     <wave></wave>" +
                                                                         "  </div>" +
                                                                        "   <div class='ws-waveform__time'>" +
                                                                         "      <span class='ws-time ws-wave_time'></span>" +
                                                                          "     <span class='ws-time ws-track_time'>" + songDetails.Rows[i]["duration"] + "</span>" +
                                                                       "    </div>" +
                                                                     "  </div>" +
                                                               "    </div>" +
                                                           "    </div>" +
                                                         "  </div>" +
                                                    "   </div>" +
                                                "   </div>" +
                                            "   </div>");

                    }

                    //sd.Append("<div class='row'>");
                    //sd.Append("<div class='col-md-12'>" + songDetails.Rows[0]["LYRICS"].ToString() + "</div>");
                    //sd.Append("</div>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sd.ToString();

        }
    

        protected void loadAwards(string uid)
        {
            ProfileServices pf = new ProfileServices();
            string spath = Get_commonFilePath();

            StringBuilder sbAwards = new StringBuilder();
            try
            {

                //string userId = "5";

                DataTable dtNews = pf.getProfileAwards(uid, "1");
                if (dtNews.Rows.Count > 0)
                {
                    for (int i = 0; i < dtNews.Rows.Count; i++)
                    {
                        string imgpath = spath + "Profile_AwardImages/" + dtNews.Rows[i]["AwardID"] + ".jpg";
                        sbAwards.Append("<div class='news-list-item'>");
                        sbAwards.Append("<div class='news-item-image'>");
                        if (dtNews.Rows[i]["ImageYN"].ToString() == "N")
                        {
                            imgpath = spath + "Profile_AwardImages/default.jpg";
                        }
                        sbAwards.Append("<img src='" + imgpath + "' width='60px' >");

                        sbAwards.Append("</div>");
                        sbAwards.Append("<div class='news-item-title'>");
                        sbAwards.Append(dtNews.Rows[i]["AwardTitle"]);
                        sbAwards.Append("</div>");
                        sbAwards.Append("<div>");
                        sbAwards.Append(dtNews.Rows[i]["Award"]);
                        sbAwards.Append("</div>");
                        sbAwards.Append("<div>");
                        sbAwards.Append(Convert.ToDateTime(dtNews.Rows[i]["CreatDateTime"].ToString()).ToString("MMMM yyyy"));
                        sbAwards.Append("</div>");
                        sbAwards.Append("</div>");



                    }
                    if (pf.moreAwardsAvailable("1", uid) > 0)
                    {
                        MoreAwards.Visible = true;
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            AwardsList.InnerHtml = sbAwards.ToString();
        }

        protected void loadCredits(string uid)
        {
            StringBuilder sbCredits = new StringBuilder();

            try
            {

                //  string userId = "5";
                ProfileServices pf = new ProfileServices();

                //get news
                DataTable dtNews = pf.getProfileCredits(uid, "1");
                if (dtNews.Rows.Count > 0)
                {
                    sbCredits.Append(" <table  border='1' cellpadding='10' id='creditsList'>");

                    for (int i = 0; i < dtNews.Rows.Count; i++)
                    {
                        sbCredits.Append("<tr>");
                        sbCredits.Append("<td>");
                        sbCredits.Append(dtNews.Rows[i]["CreditLine1"]);
                        sbCredits.Append("</td>");
                        sbCredits.Append("<td>");
                        sbCredits.Append(dtNews.Rows[i]["CreditLine2"]);
                        sbCredits.Append("</td>");
                        sbCredits.Append("<td>");
                        sbCredits.Append(dtNews.Rows[i]["CreditLine3"]);
                        sbCredits.Append("</td>");
                        sbCredits.Append("</tr>");

                    }
                    sbCredits.Append("</table>");
                    if (pf.moreCreditsAvailable("1", uid) > 0)
                    {
                        morecredits.Visible = true;
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            divCredits.InnerHtml = sbCredits.ToString();
        }

        public string Get_commonFilePath()
        {
            return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["WebURL"].ToString();
        }

        protected void loadNews(string uid)
        {
            StringBuilder sbNews = new StringBuilder();
            try
            {

                // string userId = "5";
                ProfileServices pf = new ProfileServices();
                string spath = Get_commonFilePath();
                //get news
                DataTable dtNews = pf.getProfileNews(uid, "1");

                if (dtNews.Rows.Count > 0)
                {

                    for (int i = 0; i < dtNews.Rows.Count; i++)
                    {
                        string imgpath = spath + "Profile_NewsImages/" + dtNews.Rows[i]["NewsID"] + ".jpg";
                        sbNews.Append("<div class='news-list-item'>");
                        sbNews.Append("<div class='news-item-image'>");


                        if (dtNews.Rows[i]["ImageYN"].ToString() == "N")
                        {
                            imgpath = spath + "Profile_NewsImages/default.jpg";
                        }
                        sbNews.Append("<img src='" + imgpath + "' width='60px' >");
                        sbNews.Append("</div>");
                        sbNews.Append("<div class='news-item-title'>");
                        sbNews.Append(dtNews.Rows[i]["NewsTitle"]);
                        sbNews.Append("</div>");
                        sbNews.Append("<div>");
                        sbNews.Append(dtNews.Rows[i]["NewsDescription"]);
                        sbNews.Append("</div>");
                        sbNews.Append("<div>");
                        sbNews.Append(Convert.ToDateTime(dtNews.Rows[i]["PublishDate"].ToString()).ToString("MMMM yyyy"));
                        sbNews.Append("</div>");
                        sbNews.Append("</div>");

                    }

                    //check more available
                    if (pf.moreNewsAvailable("1", uid) > 0)
                    {
                        morenews.Visible = true;
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            newslist.InnerHtml = sbNews.ToString();
        }

        protected void loadReviews(string uid)
        {
            StringBuilder sbReviews = new StringBuilder();
            try
            {

                //string userId = "5";
                ProfileServices pf = new ProfileServices();

                //get news
                DataTable dtNews = pf.getProfileReviews(uid, "1");
                if (dtNews.Rows.Count > 0)
                {
                    for (int i = 0; i < dtNews.Rows.Count; i++)
                    {
                        sbReviews.Append("<div class='news-item'>");
                        sbReviews.Append("<div class='news-desc'>");

                        sbReviews.Append("<p><i>");
                        sbReviews.Append(dtNews.Rows[i]["Review"]);
                        sbReviews.Append("<i></p>");
                        sbReviews.Append("</div>");
                        sbReviews.Append("<h5>");
                        sbReviews.Append(dtNews.Rows[i]["WriteBy"]);
                        sbReviews.Append("</h5>");
                        sbReviews.Append("<span>");
                        sbReviews.Append(dtNews.Rows[i]["Institute"]);
                        sbReviews.Append("</span>");
                        sbReviews.Append("</div>");

                    }
                    //check more available
                    if (pf.moreReviewsAvailable("1", uid) > 0)
                    {
                        moreReviews.Visible = true;
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            reviewsList.InnerHtml = sbReviews.ToString();
        }

        protected void loadPhotos(string uid)
        {

            string vCode = "";
            ProfileServices pf = new ProfileServices();
            StringBuilder sb = new StringBuilder();

            DataTable dtVP = pf.getPhotos(uid);

            if (dtVP.Rows.Count > 0)
            {
                lblPhotoTitle.Visible = true;
                photosdiv.Visible = true;
                for (int i = 0; i < dtVP.Rows.Count; i++)
                {


                    vCode = " <img    src='http://app.hitlicense.com/Profile_ManagesPhotos/" + dtVP.Rows[i]["PrifileVideoPhotoID"].ToString() + ".jpg'  height='200'   width='180' class='img-responsive' />";

                    sb.Append("<div class='col-md-3'>");
                    sb.Append(vCode);
                    sb.Append("</div>");


                }


            }
            divPhotos.InnerHtml = sb.ToString();
        }

        protected void loadVideos(string uid)
        {

            string vCode = "";
            ProfileServices pf = new ProfileServices();
            StringBuilder sb = new StringBuilder();
            string ac = "";
            DataTable dtVP = pf.getVideos(uid);

            if (dtVP.Rows.Count > 0)
            {
                lblVideoTitle.Visible = true;
                videosdiv.Visible = true;
                int count = 0;
                for (int i = 0; i < dtVP.Rows.Count; i++)
                {

                    count += 1;
                    ac = (i == 0 ? "active" : "");

                    /*if (i == 0)
                   {
                       ac = "active";
                   }
                   else {
                       ac = "";
                   }*/

                    if (count == 1)
                    {
                        sb.Append("<div class='item item-p " + ac + "'>");
                    }


                    // sb.Append("<div class='item " + ac + "'>");


                    string vURL = dtVP.Rows[i]["FileUrl"].ToString();
                    vURL = vURL.Replace("https://", "http://");
                    //if (IsYouTubeUrl(vURL))
                    //{
                    vCode = GetYouTubeVideo(vURL);
                    vCode = "<iframe src='http://www.youtube.com/embed/" + vCode + "' allowfullscreen=''   width='100%' frameborder='0' ></iframe>";


                    sb.Append("<div class='col-xs-6'>");
                    sb.Append(vCode);
                    sb.Append("</div>");

                    if ((count == 2) || (i == dtVP.Rows.Count - 1))
                    {
                        sb.Append("</div>");
                        count = 0;
                    }


                }


            }
            divVideos.InnerHtml = sb.ToString();
        }

        private static bool IsYouTubeUrl(string testUrl)
        {
            // return TestUrl(@"^(http://youtu\.be/([a-zA-Z0-9]|_)+($|\?.*)|https?://www\.youtube\.com/watch\?v=([a-zA-Z0-9]|_)+($|&).*)", testUrl);
            return TestUrl(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)", testUrl);
        }

        private static bool IsVimeoUrl(string testUrl)
        {
            return TestUrl(@"^http://(vimeo\.com/(?:.*#|.*/videos/)?([0-9]+))", testUrl);
        }

        private static bool IsDailyMotionUrl(string testUrl)
        {
            return TestUrl(@"^http://(dailymotion\.com/(?:.*/video/)?([0-9]+))", testUrl);
        }

        private static bool TestUrl(string pattern, string testUrl)
        {
            Regex l_expression = new Regex(pattern, RegexOptions.IgnoreCase);

            return l_expression.Matches(testUrl).Count > 0;
        }

        private const string YoutubeLinkRegex = "(?:.+?)?(?:\\/v\\/|watch\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";

        private static string GetYouTubeVideo(string testUrl)
        {
            string vcode = "";
            var regex = new Regex(YoutubeLinkRegex, RegexOptions.Compiled);
            foreach (Match match in regex.Matches(testUrl))
            {
                //Console.WriteLine(match);
                foreach (var groupdata in match.Groups.Cast<Group>().Where(groupdata => !groupdata.ToString().StartsWith("http://") && !groupdata.ToString().StartsWith("https://") && !groupdata.ToString().StartsWith("youtu") && !groupdata.ToString().StartsWith("www.")))
                {
                    return vcode = groupdata.ToString();
                }
            }
            return vcode;
            // return string.Empty;
            ///(?:youtu\.be\/|youtube\.com(?:\/embed\/|\/v\/|\/watch\?v=|\/user\/\S+|\/ytscreeningroom\?v=))([\w\-]{10,12})\b/
            // return GetVideo(@"(/[^watch]|=)([a-zA-z0-9]|_)+($|(\?|&))", @"([a-zA-z0-9]|_)+", testUrl);
            //return GetVideo(@"(/[^watch]|=)([a-zA-z0-9]|_)+($|(\?|&))", @"([a-zA-z0-9]|_)+", testUrl);
        }

        private static string GetVimeoVideo(string testUrl)
        {
            return GetVideo(@"/[0-9]+($|\?)", @"[0-9]+", testUrl);
        }

        private static string GetDailyMotionVideo(string testUrl)
        {
            return GetVideo(@"/[0-9]+($|\?)", @"[0-9]+", testUrl);
        }

        private static string GetVideo(string overallPattern, string videoPattern, string testUrl)
        {
            Regex l_overallExpression = new Regex(overallPattern, RegexOptions.IgnoreCase);
            MatchCollection l_overallMatches = l_overallExpression.Matches(testUrl);

            if (l_overallMatches.Count > 0)
            {
                Regex l_videoExpression = new Regex(videoPattern, RegexOptions.IgnoreCase);

                return l_videoExpression.Matches(l_overallMatches[0].Value)[0].Value;
            }
            else
            {
                return "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ProfileServices pf = new ProfileServices();
                //string userId = Page.RouteData.Values["Id"].ToString();
                string preWord = "artists";
                string screenName = Page.RouteData.Values["Id"].ToString();
                string userId = pf.getUserIdUsingScreenName(screenName);
                if (Page.RouteData.Values["version"] != null)
                {
                    string preview_version = Page.RouteData.Values["version"].ToString();

                    if (preview_version != "")
                    {
                        preWord = "preview/beta";
                    }

                }



                lnkNews.Visible = false;
                lnkCredits.Visible = false;
                lnkAwards.Visible = false;
                lnkReviews.Visible = false;
                videosdiv.Visible = false;
                photosdiv.Visible = false;
                if (userId == "")
                {
                    Response.Redirect("~/Default.aspx", true);
                }
                else
                {
                    //check profile public private view
                    string publicStatus = pf.getProfilePublicPrivate(userId);
                    if (publicStatus == "N" && preWord == "artists")
                    {
                        Response.Redirect("~/PagePrivate.aspx", true);
                    }
                    else
                    {
                        Session["userId"] = userId;
                    }

                }
                              
      
                try
                {

                    bioMore.Visible = false;
                    loadPersonalInfo();
                   string sl =  loadSongs();
                   songsList.InnerHtml = sl.ToString();
                   
                }
                catch (Exception ex)
                {
                    throw ex;
                    //Response.Redirect("../Default.aspx");
                }

                //RtMysongs.DataSource = SongTable;
                //RtMysongs.DataBind();
            }
          
        }


       
    }
}