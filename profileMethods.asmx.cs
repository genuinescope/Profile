using SongCatalog.MPM.Utils;
using SongCatelogApp.MPM_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;

namespace SongCatelogApp
{
    /// <summary>
    /// Summary description for profileMethods
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class profileMethods : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public bool checkMoreSongsAvailable(string userid, int lastloadedSongsCount)
        {
            bool output = false;
            ProfileServices pf = new ProfileServices();
            string uid = pf.getUserIdUsingScreenName(userid);
            StringBuilder sd = new StringBuilder();
            try
            {


                int scount = pf.getSongsCount(uid);
                if (scount > lastloadedSongsCount)
                {
                    output = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return output;

        }

        [WebMethod]
        public string loadSongs(string userid, int songstart)
        {
            ProfileServices pf = new ProfileServices();
            string uid = pf.getUserIdUsingScreenName(userid);
            StringBuilder sd = new StringBuilder();
            try
            {

               
                DataTable songDetails = pf.getSongsList(uid, songstart);
                if (songDetails.Rows.Count > 0)
                {
                    for (int i = 0; i < (songDetails.Rows.Count); i++)
                    {

                        string peaks = (songDetails.Rows[i]["peakVal"].ToString() != null) ? songDetails.Rows[i]["peakVal"].ToString() : "[]";
                       // string coverArt = (System.IO.File.Exists(@"C:\\inetpub\\wwwroot\\Hitlicense\\Profile_SongImage\\" + songDetails.Rows[i]["id"].ToString() + ".jpg")) ? "http://app.hitlicense.com/Profile_SongImage/" + songDetails.Rows[i]["id"].ToString() + ".jpg" : ((System.IO.File.Exists(@"C:\\inetpub\\wwwroot\\Hitlicense\\Profile_UserImage\\" + songDetails.Rows[i]["uploader"].ToString() + "_user.jpg")) ? "http://app.hitlicense.com/Profile_UserImage/" + songDetails.Rows[i]["uploader"].ToString() + "_user.jpg" : "http://app.hitlicense.com/Profile_SongImage/default_cropImg.jpg");



                        sd.Append("<div class='ws-soundList__item ws-have-cover' data-id='"+songDetails.Rows[i]["id"]+"'>"+
                                                "<div role='group' class='ws-sound'>"+
                                                    "<div class='ws-sound__body'>"+
                                                     "   <div class='ws-sound__artwork'>"+
                                                      "      <a class='ws-sound__coverArt' href='" + songDetails.Rows[i]["imgpath"].ToString() + "' data-cover='background-image: url('" + songDetails.Rows[i]["imgpath"].ToString() + "');'>" +
                                                       "        <span class='ws-image ws-artwork ws-artwork-placeholder'>"+
                                                        "            <span style='background-image: url(&quot;" + songDetails.Rows[i]["imgpath"].ToString() + "&quot;);' class='ws-artwork ws-image__thumb' aria-role='img'></span>" +
                                                               "    </span>"+
                                                         "   </a>"+
                                                        "</div>"+
                                                        "<div class='ws-sound__content'>"+
                                                         "   <div class='ws-visualSound__wrapper '>"+
                                                          "      <div class='ws-sound__header'>"+
                                                                    "   <div class='ws-soundTitle ws-clearfix'>"+
                                                                        "   <div class='ws-soundTitle__titleContainer'>"+
                                                                            "   <div class='ws-soundTitle__playButton'>"+
                                                                                "   <span class='ws-button ws-button-play' tabindex='0' title='Play'>Play</span>"+
                                                                             "  </div>"+
                                                                             "  <div class='ws-soundTitle__titleWrapper'>"+
                                                                                 "  <div class='ws-soundTitle__secondary ws-type-light'><a href='' class='ws-link-light'><span>" + songDetails.Rows[i]["songTitle"] + "</span></a></div>" +
                                                                                 "  <a class='ws-soundTitle__title ws-link-dark' href=''>"+
                                                                                   " <span>" + songDetails.Rows[i]["artist"] + "</span>" +
                                                                                "   </a>"+
                                                                             "  </div>"+
                                                                             "  <div class='ws-soundTitle__additionalContainer'>"+
                                                                                "   <div class='ws-soundTitle__tags'>&nbsp;</div>"+
                                                                                 "  <div class='ws-soundTitle__catContainer'>"+
                                                                                 "  </div>"+
                                                                             "  </div>"+
                                                                         "  </div>"+
                                                                     "  </div>"+
                                                                 "  </div>"+
                                                                 "  <div class='ws-sound__waveform'>"+
                                                                        "  <div class='ws-waveform'>"+
                                                                         "  <div class='ws-waveform__layer' data-key='ws" + songDetails.Rows[i]["id"] + "' data-file='http://app.hitlicense.com/Hit_Songs/" + songDetails.Rows[i]["songId"] + ".mp3' data-peaks='" + peaks + "'>" +
                                                                          "     <wave></wave>"+
                                                                         "  </div>"+
                                                                        "   <div class='ws-waveform__time'>"+
                                                                         "      <span class='ws-time ws-wave_time'></span>"+
                                                                          "     <span class='ws-time ws-track_time'>" + songDetails.Rows[i]["duration"] + "</span>" +
                                                                       "    </div>"+
                                                                     "  </div>"+
                                                               "    </div>"+
                                                           "    </div>"+
                                                         "  </div>"+
                                                    "   </div>"+
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
        [WebMethod]
        public string GetSongLyrics(string SongID)
        {
            StringBuilder sd = new StringBuilder();
            try
            {

                ProfileServices pf = new ProfileServices();
                DataTable songDetails = pf.GetSongLyrics(SongID);
                if (songDetails.Rows.Count > 0)
                {
                    sd.Append("<div class='row'>");
                    sd.Append("<div class='col-md-12'>" + songDetails.Rows[0]["lyrics"].ToString() + "</div>");
                    sd.Append("</div>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sd.ToString();

        }

        [WebMethod]
        public string GetSongMetadataDetails(string SongID)
        {
            StringBuilder sd = new StringBuilder();
            try
            {

                ProfileServices pf = new ProfileServices();
                DataTable songDetails = pf.GetSongMetadataDetails(SongID);
                if (songDetails.Rows.Count > 0)
                {
                    sd.Append("<div class='row'>");
                    
                    
                                 sd.Append("<div class='col-md-6'>");
                                 sd.Append("<div class='info-label'> Writer(s) / Composer(s)</div>");
                                 sd.Append("<div class='info-view'>" + songDetails.Rows[0]["WRITERS"].ToString() + "</div>");
                                 sd.Append("<div class='info-label'> Artist / Performer(s)</div>");
                                 sd.Append("<div class='info-view'>" + songDetails.Rows[0]["ARTIST"].ToString() + "</div>");
                                 sd.Append("<div class='info-label'>ISWC#</div>");
                                 sd.Append("<div class='info-view'>" + songDetails.Rows[0]["ISWC"].ToString() + "</div>");
                                 sd.Append("</div>");
                                 sd.Append("<div class='col-md-6'>");
                                 sd.Append("<div class='info-label'>Publisher(s)</div>");
                                 sd.Append("<div class='info-view'>" + songDetails.Rows[0]["PUBLISHER"].ToString() + "</div>");
                                 sd.Append("<div class='info-label'>Label</div>");
                                 sd.Append("<div class='info-view'>" + songDetails.Rows[0]["LABLE"].ToString() + "</div>");
                                 sd.Append("</div>");

                   
                    
                    sd.Append("</div>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sd.ToString();

        }

        [WebMethod]
        public string GetSongDetails(string SongID)
        {
            StringBuilder sd = new StringBuilder();
            try
            {

                ProfileServices pf = new ProfileServices();
                DataTable songDetails = pf.GetSongDetails(SongID);
                if (songDetails.Rows.Count > 0)
                {
                    sd.Append("<div class='row'>");
                    
                  
                        sd.Append("<div class='col-md-6'>");
                                sd.Append("<div class='info-label'>Song Title</div>");
                                sd.Append("<div class='info-view'>" + songDetails.Rows[0]["songTitle"].ToString() + "</div>");
                                sd.Append("<div class='info-label'>Artist / Performer </div>");
                                sd.Append("<div class='info-view'>" + songDetails.Rows[0]["artist"].ToString() + "</div>");
                                string genres = "";
                                //get genre            
                                string songPriGenre = pf.GetSongGenreforPopup(SongID);
                                genres = songPriGenre;
                                string songSecGenre = pf.GetSecSongGenreforPopup(SongID);
                                if (songPriGenre != "" && songSecGenre!="")
                                {
                                    genres = genres + ",";
                                }
                                genres = genres + songSecGenre;
                                sd.Append("<div class='info-label'>Genre(s)</div>");
                                sd.Append("<div class='info-view'>" + genres + "</div>");
                                //sd.Append("<div class='info-label'>Secondary Genre</div>");
                               // sd.Append("<div class='info-view'>" + songSecGenre + "</div>");
                                sd.Append("<div class='info-label'>Vocal Mix Value </div>");
                                sd.Append("<div class='info-view'>" + songDetails.Rows[0]["VocalMix"].ToString() + "</div>");
                                sd.Append("</div>");

                                sd.Append("<div class='col-md-6'>");
                                sd.Append("<div class='info-label'>Tempo</div>");
                                sd.Append("<div class='info-view'>" + songDetails.Rows[0]["TEMPO"].ToString() + "</div>");
                                sd.Append("<div class='info-label'>BPM</div>");
                                sd.Append("<div class='info-view'>" + songDetails.Rows[0]["BPM"].ToString() + "</div>");
                                sd.Append("<div class='info-label'>Featured Instrument</div>");
                                sd.Append("<div class='info-view'>" + songDetails.Rows[0]["FeaturedInstrument"].ToString() + "</div>");
                                sd.Append("<div class='info-label'>Key Words</div>");
                                sd.Append("<div class='info-view'>" + songDetails.Rows[0]["KeyWord"].ToString() + "</div>");
                                sd.Append("</div>");

                 
                    
                    sd.Append("</div>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sd.ToString();

        }

        [System.Web.Services.WebMethod]
        public  string loadMoreAwards(string nextPage, string userId)
        {
            ProfileServices pf = new ProfileServices();
            string uid = pf.getUserIdUsingScreenName(userId);
            StringBuilder sbNews = new StringBuilder();
            string spath = Get_commonFilePath();

            try
            {

                //string userId = "5";
               
                DataTable dtNews = pf.getProfileAwards(uid, nextPage);
                if (dtNews.Rows.Count > 0)
                {
                    for (int i = 0; i < dtNews.Rows.Count; i++)
                    {
                        string imgpath = spath + "Profile_AwardImages/" + dtNews.Rows[i]["AwardID"] + ".jpg";
                        sbNews.Append("<div class='news-list-item'>");
                        sbNews.Append("<div class='news-item-image'>");

                        if (dtNews.Rows[i]["ImageYN"].ToString() == "N")
                        {
                            imgpath = spath + "Profile_AwardImages/default.jpg";
                        }
                        sbNews.Append("<img src='" + imgpath + "' width='60px' >");

                        sbNews.Append("</div>");
                        sbNews.Append("<div class='news-item-title'>");
                        sbNews.Append(dtNews.Rows[i]["AwardTitle"]);
                        sbNews.Append("</div>");
                        sbNews.Append("<div>");
                        sbNews.Append(dtNews.Rows[i]["Award"]);
                        sbNews.Append("</div>");
                        sbNews.Append("<div>");
                        sbNews.Append(Convert.ToDateTime(dtNews.Rows[i]["CreatDateTime"].ToString()).ToString("MMMM yyyy"));
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

        [System.Web.Services.WebMethod]
        public  string loadMoreCredits(string nextPage, string userId)
        {

            StringBuilder sbNews = new StringBuilder();
            try
            {

                //  string userId = "5";
                ProfileServices pf = new ProfileServices();
                string uid = pf.getUserIdUsingScreenName(userId);
                //get news
                DataTable dtNews = pf.getProfileCredits(uid, nextPage);
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
        public  string loadMoreReviews(string nextPage, string userId)
        {
            StringBuilder sbNews = new StringBuilder();
            try
            {

                //string userId = "5";
                ProfileServices pf = new ProfileServices();
                string uid = pf.getUserIdUsingScreenName(userId);
                //get news
                DataTable dtNews = pf.getProfileReviews(uid, nextPage);
                if (dtNews.Rows.Count > 0)
                {
                    for (int i = 0; i < dtNews.Rows.Count; i++)
                    {
                        sbNews.Append("<div class='news-item'>");
                        sbNews.Append("<div class='news-desc'>");
                        sbNews.Append("<h5>");
                        sbNews.Append(dtNews.Rows[i]["WriteBy"]);
                        sbNews.Append("</h5>");
                        sbNews.Append("<p><i>");
                        sbNews.Append(dtNews.Rows[i]["Review"]);
                        sbNews.Append("<i></p>");
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
   


        [System.Web.Services.WebMethod]
        public string loadVideosPhotos(string userId)
        {
            string vCode = "";
            ProfileServices pf = new ProfileServices();
            StringBuilder sb = new StringBuilder();
            string uid = pf.getUserIdUsingScreenName(userId);
            DataTable dtVP = pf.getVideos(uid);
            if (dtVP.Rows.Count > 0)
            {
                for (int i = 0; i < dtVP.Rows.Count; i++)
                {
                    string ac = "";
                    if (i == 0)
                    {
                        ac = "active";
                        sb.Append("<div class='item " + ac + "'>");
                    }
                    if ((i % 3 == 2))
                    {
                        sb.Append("<div class='item " + ac + "'>");
                    }
                    //if (i==0 || (i % 3 == 2) )
                    //{
                    //    sb.Append("<div class='item " + ac + "'>");
                    //}
               
                    if (dtVP.Rows[i]["FileType"].ToString().Trim().ToUpper() == "V")
                    {

                        string vURL = dtVP.Rows[i]["FileUrl"].ToString();
                        vURL = vURL.Replace("https://", "http://");
                        if (IsYouTubeUrl(vURL))
                        {
                            vCode = GetYouTubeVideo(vURL);
                            vCode = "<iframe src='http://www.youtube.com/embed/" + vCode + "' allowfullscreen='' height='200' frameborder='0' width='180'></iframe>";

                        }
                        else if (IsVimeoUrl(vURL))
                        {
                            vCode = GetVimeoVideo(vURL);
                            vCode = "<iframe src='https://player.vimeo.com/video/" + vCode + "' allowfullscreen='' height='200' frameborder='0' width='180'></iframe>";

                        }

                    }
                    else
                    {
                        vCode = " <img    src='http://app.hitlicense.com/Profile_ManagesPhotos/" + dtVP.Rows[i]["PrifileVideoPhotoID"].ToString() + ".jpg'  height='200'   width='180' class='img-responsive' />";
                        //sb.Append("<div class='col-md-4'>");
                        //sb.Append(vCode);
                        //sb.Append("</div>");
                    }

                    sb.Append("<div class='col-md-4'>");
                    sb.Append(vCode);
                    sb.Append("</div>");

                    if ((i % 3 == 2))
                    {
                        sb.Append("</div>");
                    }
                    
                }


            }
            return sb.ToString();
        }
        
        
        [System.Web.Services.WebMethod]
        public int checkmoreAvailableCredits(string nextPage, string userId)
        {
            ProfileServices pf = new ProfileServices();
            string uid = pf.getUserIdUsingScreenName(userId);
            return pf.moreCreditsAvailable(nextPage, uid);
        }

        [System.Web.Services.WebMethod]
        public int checkmoreAvailableReviews(string nextPage, string userId)
        {
            ProfileServices pf = new ProfileServices();
            string uid = pf.getUserIdUsingScreenName(userId);
            return pf.moreReviewsAvailable(nextPage, uid);
        }

        [System.Web.Services.WebMethod]
        public int checkmoreAvailableAwards(string nextPage, string userId)
        {
            ProfileServices pf = new ProfileServices();
            string uid = pf.getUserIdUsingScreenName(userId);
            return pf.moreAwardsAvailable(nextPage, uid);
        }

        [System.Web.Services.WebMethod]
        public int checkmoreAvailableNews(string nextPage, string userId)
        {
            ProfileServices pf = new ProfileServices();
            string uid = pf.getUserIdUsingScreenName(userId);
            return pf.moreNewsAvailable(nextPage,uid);
        }

        public bool checkImageExists(string imagePath) {
            System.Net.HttpWebRequest request = null;
            System.Net.HttpWebResponse response = null;
            bool flag = false;
            request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create("www.example.com/somepath");
            request.Timeout = 30000;
            try
            {
                response = (System.Net.HttpWebResponse)request.GetResponse();
                flag = true;
            }
            catch
            {
                flag = false;
            }

            return flag;
        }

        public string Get_commonFilePath() {
            return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["WebURL"].ToString(); 
        }


        [System.Web.Services.WebMethod]
        public  string loadMoreNews(string nextPage, string userId)
        {
            
            StringBuilder sbNews = new StringBuilder();
            try
            {

                // string userId = "5";
                ProfileServices pf = new ProfileServices();
                string uid = pf.getUserIdUsingScreenName(userId);
                //get news
                DataTable dtNews = pf.getProfileNews(uid, nextPage);
                string spath = Get_commonFilePath();
                if (dtNews.Rows.Count > 0)
                {

                    for (int i = 0; i < dtNews.Rows.Count; i++)
                    {
                        string imgpath = spath+"Profile_NewsImages/" + dtNews.Rows[i]["NewsID"] + ".jpg";
                        sbNews.Append("<div class='news-list-item'>");
                        sbNews.Append("<div class='news-item-image'>");

                        if (dtNews.Rows[i]["ImageYN"].ToString()=="N")
                        {
                            imgpath = spath + "Profile_NewsImages/default.jpg";
                        }

                        sbNews.Append("<img src='"+imgpath+"' width='60px' >");
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

                }
       

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sbNews.ToString();
        }


        [System.Web.Services.WebMethod]
        public string bioLoadMore(string userId)
        {
            ProfileServices pf = new ProfileServices();
            string uid = pf.getUserIdUsingScreenName(userId);
            DataTable dtProfileInfo = pf.getProfileInfo(uid);
            return dtProfileInfo.Rows[0]["BIO"].ToString();

        }
        [System.Web.Services.WebMethod]
        public string sendEmail(string userid, string fromname, string email, string subject, string message)
        {
            ProfileServices pf = new ProfileServices();
            string userEmail = pf.getUserEmailUsingScreenName(userid);

            MailHandler oH = new MailHandler();
            oH.SendMailUser(userEmail, fromname, email, subject, message);

            return "";

        }

        

    }
}
