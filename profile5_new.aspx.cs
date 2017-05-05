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

namespace SongCatelogApp
{

    public partial class profile5_new : System.Web.UI.Page
    {
        public DBConnection DBUtils = new DBConnection();
        

        protected void loadPersonalInfo() {
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
            string artTypes="";
            for(int t=0;t<dtt.Rows.Count;t++){
                artTypes += dtt.Rows[t]["ArtistType"].ToString()+", ";
            }
            if (artTypes.Length>=2)
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
                id_flag.Attributes.Add("src", "http://testapp.hitlicense.com/flags/" + dtu.Rows[0]["Country"].ToString() + ".png");
                
                imgProfile.Attributes.Add("src", "http://testapp.hitlicense.com/Profile_UserImage/" + dtu.Rows[0]["UserID"].ToString() + "_user.jpg");
                imgCover.Attributes.Add("src", "http://testapp.hitlicense.com/Profile_CoverPhoto/" + dtu.Rows[0]["UserID"].ToString() + "_Cover.jpg");
                //lblJoined.Text = Convert.ToDateTime(dtu.Rows[0]["JoineDate"].ToString()).ToString("MMMM yyyy");

                pweb.Visible = false;
                pfb.Visible = false;
                pt.Visible = false;
                plink.Visible = false;
                psc.Visible = false;
                pins.Visible = false;

                if (dtu.Rows[0]["webSite"].ToString()!="")
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
                    //sociallinks.Visible = true;
                }
                

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
                else {
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

                if (dtu.Rows[0]["News_OnOff"].ToString()=="True")
                {
                    lnkNews.Visible = true;
                    if (tabactive==0)
                    {
                        lnkNews.Attributes.Add("class","active");
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
                if (dtu.Rows[0]["Video_OnOff"].ToString() == "True")
                {
                    loadVideos(userId);
                    loadPhotos(userId);
                }
       
              

            }

        }

        protected string loadfirstSongs()
        {
            return "";
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

            reviewsList.InnerHtml =  sbReviews.ToString();
        }

        protected void loadPhotos(string uid)
        {

            string vCode = "";
            ProfileServices pf = new ProfileServices();
            StringBuilder sb = new StringBuilder();

            DataTable dtVP = pf.getPhotos(uid);
            string ac = "";
            if (dtVP.Rows.Count > 0)
            {
                photosdiv.Visible = true;
                for (int i = 0; i < dtVP.Rows.Count; i++)
                {
                    
                    if (i == 0)
                    {
                        ac = "active";
                       
                    }
                    else{
                        ac = "";
                    }
             

                    sb.Append("<div class='item " + ac + "'>");
                    vCode = " <img    src='http://testapp.hitlicense.com/Profile_ManagesPhotos/" + dtVP.Rows[i]["PrifileVideoPhotoID"].ToString() + ".jpg'  height='200'   width='180' class='img-responsive' />";
             
                    sb.Append("<div class='col-md-3'>");
                    sb.Append(vCode);
                    sb.Append("</div>");

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
                videosdiv.Visible = true;
                for (int i = 0; i < dtVP.Rows.Count; i++)
                {

                    if (i == 0)
                    {
                        ac = "active";
                    }
                    else {
                        ac = "";
                    }
               
                        sb.Append("<div class='item " + ac + "'>");
               
            
                        string vURL = dtVP.Rows[i]["FileUrl"].ToString();
                        vURL = vURL.Replace("https://", "http://");
                        //if (IsYouTubeUrl(vURL))
                        //{
                        vCode = GetYouTubeVideo(vURL);
                        vCode = "<iframe src='http://www.youtube.com/embed/" + vCode + "' allowfullscreen=''  height='200' frameborder='0' ></iframe>";


                    sb.Append("<div class='col-xs-3'>");
                    sb.Append(vCode);
                    sb.Append("</div>");

                    sb.Append("</div>");
          

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
                if (Page.RouteData.Values["version"]!=null)
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
                else {
                    //check profile public private view
                    string publicStatus = pf.getProfilePublicPrivate(userId);
                    if (publicStatus == "N" && preWord == "artists")
                    {
                        Response.Redirect("~/PagePrivate.aspx", true);
                    }
                    else {
                        Session["userId"] = userId;
                    }
                    
                }

                string filterq = Page.RouteData.Values["pageType"].ToString();
                string albumId = Page.RouteData.Values["albumId"].ToString();
                int pagesize = 5;
                // string filterq = Request.QueryString["page"].ToString();
                if (filterq.ToString().Trim() == "all")
                {
                    Session["filter"] = "all";
                    pagesize = 10;
                    this.CurrentPageId = "1";
                    lnkAllSongs.Attributes.Add("class", "current");
                }
                if (filterq.ToString().Trim() == "featured")
                {
                    Session["filter"] = "featured";
                    pagesize = 5;
                    lnkFeatured.Attributes.Add("class","current");
                    //pagesize = 4;
                    //this.CurrentPageId = "1";
                }
                if (filterq.ToString().Trim() == "playlists")
                {
                    Session["filter"] = "playlists";
                    pagesize = 10;
                    this.CurrentPageId = "1";
                    lblPlaylists.Attributes.Add("class", "current");
                }
                try
                {

                    //string userId = Request.QueryString["userID"].ToString();
                    lnkAllSongs.HRef = "/" + preWord + "/" + screenName + "/all";
                    lnkFeatured.HRef = "/" + preWord + "/" + screenName + "/featured";
                    lblPlaylists.HRef = "/" + preWord + "/" + screenName + "/playlists";

                    string filte = Session["filter"].ToString();
                    bioMore.Visible = false;

                    loadPersonalInfo();

                    loadfirstSongs();


                    if (filterq == "playlists" && albumId == "0")
                    {
                        songs.Visible = false;
                        playlists.Visible = true;

                        string sql = "SELECT * FROM PlayListHeader WHERE PlayListHeaderID IN (select PlayListHeaderID from dbo.PlayList) and RecStatus='AC' AND UserID='" + userId + "'";
                        DataTable dt = DBUtils.ExecuteQuery(sql);

                        StringBuilder playlist = new StringBuilder();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            
                            string img = dt.Rows[i]["PlayListHeaderID"].ToString()+".jpg";
                            string path = @"C:\\inetpub\\wwwroot\\Hitlicense\\Profile_AlbumImage\\" + img ;

                          
                            if(System.IO.File.Exists(path)){
                                img = dt.Rows[i]["PlayListHeaderID"].ToString() + ".jpg";
                            }
                            else{
                             img = "default.jpg";
                            }

                            string sqlc = "SELECT count(*) as scount FROM PlayList WHERE PlayListHeaderID=" + dt.Rows[i]["PlayListHeaderID"].ToString();
                            DataTable dtc = DBUtils.ExecuteQuery(sqlc);


                            playlist.Append("<div class='play-view-name'><a href='/" + preWord + "/" + screenName + "/playlists/" + dt.Rows[i]["PlayListHeaderID"].ToString() + "'><img src='http://testapp.hitlicense.com//Profile_AlbumImage/" + img + "' width='150' height='150'><div class='play-list-info'> <span>" + dt.Rows[i]["AlbumName"].ToString() + "</span><br>  <span>Songs " + dtc.Rows[0]["scount"].ToString() + "</span></div></a></div>");
                        }

                        playlists.InnerHtml = playlist.ToString();

                    }
                    else {

                       string sql = "";
                        if (Session["filter"] == "all")
                        {
                            sql = "SELECT * FROM Songs WHERE status<>10 and uploader='" + userId + "' AND AddtoProfile='Y' order by id ";

                        }
                        if (Session["filter"] == "featured")
                        {
                            sql = "SELECT * FROM Songs WHERE status<>10 and uploader='" + userId + "' AND AddtoProfile='Y' AND Featured=1   order by id ";

                        }

                        if (filterq == "playlists" && albumId != "0")
                        {
                            StringBuilder sbd = new StringBuilder();
                            string sqld = "SELECT * FROM PlayListHeader WHERE PlayListHeaderID=" + albumId;
                            DataTable dtd = DBUtils.ExecuteQuery(sqld);
                            sbd.Append("<div class='playlist_details'>");
                            sbd.Append("<h5>" + dtd.Rows[0]["AlbumName"].ToString() + "</h5>");

                            string img = dtd.Rows[0]["PlayListHeaderID"].ToString() + ".jpg";
                            string path = @"C:\\inetpub\\wwwroot\\Hitlicense\\Profile_AlbumImage\\" + img;


                            if (System.IO.File.Exists(path))
                            {
                                img = dtd.Rows[0]["PlayListHeaderID"].ToString() + ".jpg";
                            }
                            else
                            {
                                img = "default.jpg";
                            }
                            sbd.Append("<div class='close-btn'><a href='/" + preWord + "/" + screenName + "/playlists'>Close</a></div>");
                            sbd.Append("<img src='http://testapp.hitlicense.com//Profile_AlbumImage/" + img + "' width='150' height='150'>");
                            sbd.Append("</div>");
                            playlistDetails.InnerHtml = sbd.ToString();
                            sql = "SELECT * FROM PlayList left join Songs on Songs.id=PlayList.SongID WHERE Songs.status<>10 AND  Songs.uploader='" + userId + "' AND PlayListHeaderID='" + albumId + "'";
                        
                        }
                        DataTable dt = DBUtils.ExecuteQuery(sql);
                        this.RowCount = dt.Rows.Count;

                        if (this.RowCount == 0) { plcPagingb.Visible = false; }

                        //if Uploaded...goto Last page
                        if (Session["UPDone"] != null)
                        {
                            if (Session["UPDone"] == null)
                            {
                                this.CurrentPageId = GetLastPageID(this.RowCount,pagesize).ToString();
                                Session["UPDone"] = null;
                            }
                            else if (Session["UPDone"] != null)
                            {
                                string zz = Session["UPDone"].ToString();
                                if (Session["UPDone"].ToString() == "Y")
                                {
                                    this.CurrentPageId = GetLastPageID(this.RowCount,pagesize).ToString();
                                    Session["UPDone"] = null;
                                }
                            }
                        }
                        //var pgs = this.RowCount/10;
                        if (this.RowCount == pagesize) this.CurrentPageId = "1";
                        if (this.CurrentPageId != null)
                        {
                            if (int.Parse(this.CurrentPageId) < 1)
                            {
                                this.CurrentPageId = "1";
                            }
                            var currentPage = int.Parse(this.CurrentPageId);
                            var take = (currentPage - 1) * pagesize;
                            var skip = currentPage == 1 ? 0 : take - pagesize;
                            take = take + 1;
                            this.FetchData(int.Parse(take.ToString()), pagesize);
                        }
                        else
                        {
                            //default load                        
                            this.CurrentPageId = "1";
                            this.FetchData(1, pagesize);
                        }

                        songs.Visible = true;
                        playlists.Visible = false;

                    }




                }
                catch (Exception ex)
                {
                    throw ex;
                    //Response.Redirect("../Default.aspx");
                }

                //RtMysongs.DataSource = SongTable;
                //RtMysongs.DataBind();
            }
            else
            {


                //   var plsHolder = this.FindControl("plcPaging");
                //   plsHolder.Controls.Clear();
                try
                {
                    if (Session["filter"].ToString() != "featured")
                    {
                        var plsHolderb = this.FindControl("plcPagingb");
                        plsHolderb.Controls.Clear();
                        this.CreatePagingControl();
                    }

                }
                catch (Exception exx)
                {
                    throw exx;
                }
            }

        }


        public void refeed_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // class="ws-waveform__layer veryfirst" data-key="ws<%# DataBinder.Eval(Container.DataItem, "id")%>" data-file="http://testapp.hitlicense.com/Hit_Songs/<%# DataBinder.Eval(Container.DataItem, "id")%>.mp3" data-peaks=""
            HiddenField hSongID = (HiddenField)e.Item.FindControl("hSongID");

            HyperLink lnkSongDetails = (HyperLink)e.Item.FindControl("lnkSongDetails");
            lnkSongDetails.Attributes.Add("onclick","songDetails("+hSongID.Value.ToString()+")");

            string sql = "SELECT * from View_UserGenreDetails where SongID=" + hSongID.Value;
            DataTable dt = DBUtils.ExecuteQuery(sql);
            string genre = "";
            if (dt.Rows.Count > 0)
            {
                for (int s = 0; s < dt.Rows.Count; s++)
                {
                    genre = genre + "<div class='divgen'>" + dt.Rows[s]["Genre"] + "</div>";
                }
            }
            HtmlGenericControl genres = ((HtmlGenericControl)(e.Item.FindControl("genre")));
            genres.InnerHtml = genre;

            string filterq = Page.RouteData.Values["pageType"].ToString();
            if (filterq=="all")
            {
                HtmlGenericControl sDetails = ((HtmlGenericControl)(e.Item.FindControl("sDetails")));
                sDetails.Attributes.Add("class","sdetails");
            }
            //if(Session["filterq"].ToString()=="featured"){
            //    HtmlGenericControl sImg = ((HtmlGenericControl)(e.Item.FindControl("sImg")));
            //    sImg.Attributes.Add("class", "ws-sound__artwork featured");
            //}
        }



        int GetLastPageID(int nRowCount,int pagesize)
        {
            //int pagesize = 3;
            int nlastPage = 1;
            float nTotPage = (nRowCount / pagesize);

            int nReminder = (nRowCount % pagesize);
            if (nTotPage > 1)
            {
                nlastPage = int.Parse(nTotPage.ToString());
                if (nReminder > 0)
                    nlastPage++;
            }
            return nlastPage;
        }


        public string CurrentPageId
        {
            get
            {
                if (!IsPostBack)
                {
                    if (Session["PageID"] == null) Session["PageID"] = "1";
                }
                return (string)Session["PageID"];
            }
            set { Session["PageID"] = value; }
        }

        #region Pagination

        private int RowCount
        {
            get
            {
                return (int)ViewState["RowCount"];
            }
            set
            {
                ViewState["RowCount"] = value;
            }
        }

        private DataTable SongTable
        {
            get { return (DataTable)ViewState["SongTable"]; }
            set { ViewState["SongTable"] = value; }
        }

        //public void refeed_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    // class="ws-waveform__layer veryfirst" data-key="ws<%# DataBinder.Eval(Container.DataItem, "id")%>" data-file="http://testapp.hitlicense.com/Hit_Songs/<%# DataBinder.Eval(Container.DataItem, "id")%>.mp3" data-peaks=""
        //    HiddenField hSongID = (HiddenField)e.Item.FindControl("hSongID");
        //    //string sql = "SELECT * from song_peaks where songId=" + hSongID.Value;
        //    //DataTable dt = DBUtils.ExecuteQuery(sql);


        //    ////string path = @"http://testapp.hitlicense.com/Hit_Songs/" + hSongID.Value + ".mp3";
        //    //HtmlGenericControl hmyAnimation = ((HtmlGenericControl)(e.Item.FindControl("divPeekID")));
        //    //if (hmyAnimation != null)
        //    //{
        //    //    string peaks = "[0.0091,-0.0076,0.0196,-0.0301,0.0365,-0.0582,0.0417,-0.0463,0.0366,-0.0134,0.0116,-0.0111,0.0044,-0.0076,0.0066,-0.0053,0.0444,-0.0042,0.0818,-0.0386,0.0254,-0.0363,0.0308,-0.0235,0.0528,-0.0143,0.0384,-0.0244,0.0214,-0.0271,0.026,-0.0596,0.06,-0.0622,0.0205,-0.0182,0.0122,-0.0125,0.0699,-0.0448,0.0736,-0.0773,0.0353,-0.0624,0.0293,-0.0285,0.0311,-0.0292,0.0277,-0.0251,0.025,-0.0252,0.0229,-0.02,0.023,-0.0191,0.0229,-0.0151,0.1014,-0.0402,0.0252,-0.0302,0.0217,-0.0271,0.0181,-0.028,0.0489,-0.0501,0.0368,-0.0325,0.0424,-0.0218,0.0327,-0.0367,0.0185,-0.0244,0.0338,-0.0274,0.0331,-0.0396,0.019,-0.0296,0.0186,-0.0152,0.02,-0.0489,0.0257,-0.049,0.032,-0.0177,0.0173,-0.0199,0.0258,-0.0436,0.0154,-0.0257,0.0098,-0.0156,0.0289,-0.0573,0.1076,-0.0905,0.0752,-0.0718,0.0428,-0.0372,0.0604,-0.0416,0.0387,-0.039,0.0429,-0.0335,0.0807,-0.053,0.057,-0.0456,0.0527,-0.053,0.0342,-0.0249,0.0271,-0.0308,0.0177,-0.0186,0.0069,-0.0084,0.0977,-0.1479,0.0574,-0.053,0.0636,-0.0487,0.0296,-0.0426,0.0435,-0.0306,0.03,-0.0281,0.0287,-0.0306,0.061,-0.0393,0.0202,-0.0235,0.0103,-0.0111,0.0104,-0.0099,0.0639,-0.0354,0.0219,-0.0323,0.029,-0.0311,0.0282,-0.0256,0.0207,-0.014,0.0326,-0.0207,0.0194,-0.0209,0.0211,-0.0153,0.0202,-0.0248,0.019,-0.0176,0.0628,-0.0653,0.007,-0.0183,0.008,-0.0086,0.0274,-0.03,0.0253,-0.0271,0.0234,-0.0223,0.0213,-0.0264,0.0272,-0.0283,0.0254,-0.0228,0.0259,-0.0261,0.0499,-0.0461,0.03,-0.0311,0.0232,-0.0381,0.0426,-0.0587,0.0307,-0.0269,0.019,-0.0392,0.0238,-0.025,0.0141,-0.034,0.0348,-0.0226,0.0193,-0.0197,0.0568,-0.0364,0.0282,-0.0633,0.0301,-0.0402,0.0391,-0.0255,0.0342,-0.0148,0.0265,-0.0209,0.0711,-0.0201,0.1179,-0.0959,0.0831,-0.1017,0.1313,-0.0896,0.0402,-0.0564,0.0246,-0.0325,0.0261,-0.0312,0.0151,-0.0208,0.111,-0.0542,0.1087,-0.0727,0.0667,-0.033,0.0326,-0.0456,0.0687,-0.0582,0.064,-0.0311,0.0673,-0.0902,0.092,-0.1116,0.0338,-0.0287,0.0352,-0.0269,0.0262,-0.0724,0.1013,-0.0669,0.0916,-0.0959,0.1171,-0.0886,0.1295,-0.1137,0.0505,-0.0417,0.0322,-0.0244,0.0324,-0.0581,0.0344,-0.093,0.0864,-0.0556,0.0903,-0.099,0.0419,-0.0737,0.0585,-0.0602,0.0369,-0.1401,0.1459,-0.0767,0.1438,-0.0608,0.0627,-0.0839,0.0548,-0.0457,0.0497,-0.0335,0.0276,-0.0405,0.0365,-0.0533,0.0281,-0.0358,0.0629,0,0.0795,-0.0794,0.0791,-0.0836,0.0217,-0.0453,0.0544,-0.0358,0.0294,-0.0155,0.0329,-0.0241,0.0341,-0.0153,0.0886,-0.1409,0.1222,-0.1424,0.0844,-0.0807,0.0516,-0.0505,0.0419,-0.0454,0.0314,-0.0485,0.0508,-0.0311,0.1272,-0.101,0.1441,-0.0797,0.0826,-0.0766,0.0811,-0.058,0.0278,-0.0176,0.0174,-0.0267,0.01,-0.0119,0.1301,-0.1199,0.1297,-0.1185,0.031,-0.0457,0.0524,-0.039,0.0845,-0.0438,0.0564,-0.0247,0.0145,-0.0415,0.0675,-0.0841,0.0233,-0.0145,0.03,-0.0157,0.0818,-0.1015,0.0933,-0.0675,0.0927,-0.0639,0.0982,-0.0797,0.154,-0.073,0.1265,-0.106,0.0987,-0.0613,0.0513,-0.0665,0.0466,-0.0381,0.0578,-0.0445,0.0589,-0.0597,0.0791,-0.0999,0.0531,-0.0467,0.0376,-0.0445,0.1083,-0.0689,0.1088,-0.0909,0.1001,-0.0796,0.0838,-0.071,0.0731,-0.0453,0.0343,-0.0853,0.0456,-0.0368,0.0553,-0.0352,0.0737,-0.0102,0.0289,-0.0539,0.0872,-0.0776,0.0456,-0.0789,0.0593,-0.0501,0.0703,-0.0372,0.0409,-0.0407,0.0203,-0.0291,0.0201,-0.0153,0.0706,-0.1167,0.0657,-0.0963,0.0766,-0.0901,0.0538,-0.1204,0.0829,-0.111,0.0575,-0.045,0.1243,-0.0848,0.0922,-0.1191,0.16,-0.1102,0.0226,-0.0839,0.034,-0.0495,0.0181,-0.0153,0.0112,-0.0163,0.0546,-0.0474,0.0717,-0.0396,0.0513,-0.0762,0.0338,-0.0496,0.0571,-0.0383,0.0286,-0.0531,0.041,-0.012,0.0836,-0.0969,0.0361,-0.0617,0.023,-0.0268,0.1163,-0.0681,0.1032,-0.1374,0.0907,-0.1041,0.0221,-0.0996,0.0527,-0.0483,0.056,-0.0236,0.0511,-0.0433,0.0611,-0.0996,0.0313,-0.0328,0.0084,-0.0323,0.0473,-0.0668,0.0623,-0.0177,0.0159,-0.024,0.0087,-0.0139,0.0516,-0.0975,0.1132,-0.0515,0.0569,-0.0763,0.0934,-0.0735,0.0748,-0.0862,0.0733,-0.0673,0.0847,-0.0036,0.0945,-0.1022,0.0496,-0.0617,0.0263,-0.0454,0.1003,-0.0873,0.0319,-0.0397,0.0344,-0.0327,0.0597,-0.031,0.0486,-0.0707,0.0452,-0.0476,0.0607,-0.0354,0.0558,-0.075,0.1016,-0.0684,0.0334,-0.0562,0.0752,-0.0584,0.033,-0.0514,0.0482,-0.0183,0.0524,-0.0676,0.0485,-0.0455,0.0336,-0.0265,0.0387,-0.0354,0.0364,-0.0521,0.0433,-0.045,0.0278,-0.0482,0.0493,-0.0448,0.0556,-0.0544,0.031,-0.0497,0.0477,-0.0373,0.0381,-0.0411,0.0402,-0.0639,0.0497,-0.0509,0.0782,-0.129,0.0798,-0.0821,0.0781,-0.0583,0.0513,-0.0307,0.0201,-0.0306,0.0175,-0.0133,0.0643,-0.0479,0.1416,-0.1142,0.0883,-0.1025,0.0832,-0.0616,0.0636,-0.0672,0.0525,-0.0547,0.0559,-0.0507,0.0909,-0.0583,0.0449,-0.0514,0.032,-0.0428,0.0335,-0.0832,0.0821,-0.0824,0.0501,-0.0821,0.0762,-0.0868,0.0397,-0.028,0.0505,-0.0671,0.0368,-0.0395,0.0373,-0.048,0.0208,-0.0195,0.0191,-0.0253,0.0153,-0.0189,0.0253,-0.0228,0.0263,-0.0247,0.0149,-0.0182,0.0169,-0.0122,0.0123,-0.0158,0.0416,-0.0693,0.0838,-0.0819,0.0738,-0.0812,0.0636,-0.0751,0.0515,-0.0348,0.0611,-0.0359,0.0352,-0.0219,0.0714,-0.04,0.1204,-0.109,0.1146,-0.0094,0.0423,-0.0558,0.1072,-0.1076,0.0673,-0.0574,0.0645,-0.0627,0.0477,-0.0686,0.0759,-0.0319,0.0348,-0.0363,0.0178,-0.0466,0.0813,-0.0546,0.0939,-0.0656,0.0521,-0.0509,0.0959,-0.1131,0.0617,-0.1184,0.0447,-0.0311,0.0418,-0.0381,0.0016,-0.0933,0.1174,-0.0767,0.0703,-0.1037,0.0606,-0.0985,0.0253,-0.0402,0.0171,-0.0205,0.0427,-0.0655,0.0025,-0.0527,0,-0.0539,0.0645,-0.0253,0.0915,-0.0341,0.0346,-0.0328,0.0186,-0.0164,0.0147,-0.0584,0.1544,-0.1086,0.0814,-0.0735,0.1156,-0.0574,0.0526,-0.0596,0.053,-0.0634,0.0361,-0.0233,0.0508,-0.0511,0.0276,-0.0697,0.0522,-0.0492,0.09,-0.0566,0.0862,-0.0369,0.0781,-0.0717,0.0257,-0.0461,0.0207,-0.0452,0.0304,-0.0274,0.0255,-0.0174,0.0416,-0.0724,0.061,-0.0679,0.0593,-0.039,0.0363,-0.0537,0.035,-0.0808,0.0252,-0.0998,0.0241,-0.0767,0.1143,-0.0963,0.0837,-0.0669,0.0317,-0.0737,0.1139,-0.1008,0.1135,-0.109,0.0995,-0.0814,0.0671,-0.0571,0.0333,-0.1156,0.0889,-0.068,0.0424,-0.0897,0.0842,-0.0739,0.0746,-0.13,0.0725,-0.0806,0.0471,-0.0453,0.0947,-0.0541,0.0645,-0.0609,0.0322,-0.0351,0.1202,-0.0778,0.0708,-0.0853,0.0499,-0.0571,0.0981,-0.0627,0.0997,-0.0527,0.0929,-0.0874,0.0716,-0.0808,0.0688,-0.0769,0.1169,-0.0609,0.1029,-0.0785,0.105,-0.0908,0.0596,-0.0408,0.0179,-0.0319,0.0642,-0.0445,0.0932,-0.0613,0.0968,-0.0705,0.0786,-0.0714,0.0525,-0.0359,0.0411,-0.016,0.0208,-0.0292,0.0546,-0.0361,0.028,-0.0614,0.0374,-0.0311,0.0203,-0.0616,0.0991,-0.0861,0.0251,-0.0991,0.0328,-0.0532,0.0368,-0.0269,0.0194,-0.0144,0.013,-0.0103,0.0694,-0.1149,0.0826,-0.107,0.1068,-0.1021,0.0824,-0.1022,0.0271,-0.0476,0.0096,-0.0352,0.0092,-0.0291,0.1624,-0.0732,0.1263,-0.1439,0.0988,-0.0966,0.0833,-0.1391,0.0529,-0.0364,0.0171,-0.0142,0.0171,-0.0207,0.0941,-0.0616,0.1043,-0.0958,0.1133,-0.0844,0.0517,-0.051,0.0706,-0.0291,0.0302,-0.0314,0.0299,-0.0494,0.0685,-0.0458,0.0278,-0.0142,0.013,-0.0134,0.0579,-0.0465,0.0622,-0.0429,0.0514,-0.0471,0.0528,-0.0403,0.0489,-0.0527,0.0385,-0.0398,0.0309,-0.0446,0.0777,-0.0895,0.0497,-0.0416,0.0313,-0.0358,0.0375,-0.0739,0.0235,-0.0407,0.0184,-0.029,0.0581,-0.0605,0.1159,-0.026,0.0331,-0.0723,0.0846,-0.0647,0.0614,-0.0439,0.102,-0.0701,0.0926,-0.1094,0.063,-0.0892,0.068,-0.0505,0.057,-0.0484,0.0906,-0.0632,0.1319,-0.0944,0.0552,-0.0539,0.0733,-0.0564,0.0523,-0.0652,0.0932,-0.0369,0.0175,-0.0555,0.0679,-0.1644,0.1278,-0.0801,0.0216,-0.1007,0.0876,-0.0902,0.052,-0.0916,0.0664,-0.0302,0.0525,-0.0709,0.0577,-0.0551,0.0577,-0.0401,0.0242,-0.0246,0.0432,-0.0401,0.0509,-0.04,0.0403,-0.0751,0.0727,-0.0519,0.0577,-0.0744,0.0321,-0.0271,0.0346,-0.0634,0.0859,-0.0494,0.0559,-0.046,0.054,-0.0361,0.0766,-0.0999,0.1003,-0.1116,0.0632,-0.0189,0.0302,-0.0462,0.0237,-0.0397,0.0155,-0.0389,0.0164,-0.0258,0.1088,-0.1099,0.1247,-0.1148,0.0387,-0.0368,0.0355,-0.0452,0.0231,-0.0244,0.0271,-0.0434,0.0385,-0.0892,0.2197,-0.1121,0.0839,-0.0873,0.1173,-0.0699,0.1084,-0.0491,0.0192,-0.0364,0.0155,-0.0237,0.0157,-0.013,0.0299,-0.0387,0.029,-0.0215,0.011,-0.0165,0.0051,-0.0083,0.0052,-0.0091,0.0039,-0.0066,0.0337,-0.0061,0.0476,-0.0716,0.012,-0.0094,0.0079,-0.0073,0.0336,-0.0133,0.0382,-0.0283,0.0139,-0.0119,0.0693,-0.0419,0.0763,-0.0843,0.0575,-0.0704,0.0643,-0.0482,0.0351,-0.0771,0.0632,-0.0271,0.0432,-0.0731,0.0747,-0.0887,0.0436,-0.0618,0.0688,-0.06,0.0227,-0.0566,0.107,-0.0497,0.1071,-0.0885,0.0985,-0.0799,0.1374,-0.0517,0.0909,-0.0525,0.0422,-0.0481,0.0428,-0.0526,0.0305,-0.0572,0.0953,-0.0511,0.0551,-0.0559,0.1113,-0.091,0.0705,-0.0944,0.065,-0.0442,0.0488,-0.0265,0.0372,-0.036,0.0299,-0.0395,0.0387,-0.0672,0.1176,-0.0713,0.0502,-0.0485,0.0455,-0.05,0.0277,-0.0272,0.0424,-0.0314,0.0245,-0.0156,0.0955,-0.1004,0.0896,-0.117,0.0919,-0.0701,0.0677,-0.0698,0.039,-0.0297,0.0198,-0.0137,0.0125,-0.0128,0.0144,-0.026,0.0153,-0.0063,0.0056,-0.0063,0.0177,-0.0208,0.0124,-0.0101,0.0056,-0.0046,0.0595,-0.0656,0.0808,-0.105,0.0316,-0.0521,0.0125,-0.0163,0.0252,-0.0279,0.0293,-0.0186,0.0097,-0.0274,0.0722,-0.0845,0.0998,-0.0631,0.038,-0.063,0.0575,-0.0616,0.0453,-0.0537,0.053,-0.048,0.0342,-0.0335,0.1305,-0.0963,0.0608,-0.05,0.0616,-0.0434,0.123,-0.1097,0.0823,-0.0757,0.0856,-0.06,0.0997,-0.0016,0.0654,-0.1039,0.1249,-0.0672,0.1368,-0.0969,0.0837,-0.0632,0.0933,-0.074,0.0306,-0.0539,0.0616,-0.0636,0.0464,-0.0796,0.0673,-0.0352,0.0696,-0.0362,0.0499,-0.0489,0.0326,-0.0431,0.0421,-0.0087,0.1002,-0.1758,0.0886,-0.0769,0.063,-0.1126,0.0469,-0.0249,0.0304,-0.0399,0.039,-0.0154,0.0547,-0.0408,0.0773,-0.1103,0.0823,-0.092,0.139,-0.0771,0.0305,-0.0237,0.0374,-0.0313,0.0196,-0.0127,0.0072,-0.0168,0.0055,-0.0182,0.0082,-0.0045,0.0183,-0.0031,0.0364,-0.0132,0.0132,-0.0037,0.0052,-0.006,0.0355,-0.0879,0.0161,-0.0274,0.0073,-0.0046,0.016,-0.0098,0.0175,-0.011,0.0075,-0.0038,0.0364,-0.044,0.1075,-0.047,0.1097,-0.0396,0.0548,-0.0372,0.0829,-0.065,0.0618,-0.0426,0.0399,-0.0089,0.0524,-0.0892,0.0848,-0.0892,0.0266,-0.0167,0.0145,-0.0103,0.0512,-0.0367,0.0472,-0.0503,0.0549,-0.0329,0.0589,-0.0432,0.0504,-0.0468,0.0356,-0.0499,0.0453,-0.027,0.0425,-0.0507,0.0413,-0.0244,0.0256,-0.0275,0.0649,-0.0695,0.0294,-0.0474,0.0608,-0.0421,0.0187,-0.0465,0.0421,-0.0339,0.0432,-0.0276,0.0454,-0.0535,0.1619,-0.1069,0.094,-0.0868,0.0685,-0.0395,0.0454,-0.0611,0.0311,-0.0469,0.0447,-0.0358,0.1484,-0.0727,0.1554,-0.0942,0.0779,-0.0822,0.0646,-0.0985,0.0449,-0.0813,0.0415,-0.0143,0.0242,-0.0167,0.0644,-0.0609,0.0854,-0.0291,0.0134,-0.0166,0.0129,-0.0177,0.0118,-0.014,0.0075,-0.0088,0.0064,-0.006,0.0591,-0.088,0.0191,-0.0425,0.0146,-0.0159,0.0208,-0.0211,0.0165,-0.0139,0.0155,-0.0156,0.0611,-0.0782,0.0554,-0.1031,0.1185,-0.1005,0.0693,-0.0929,0.0603,-0.0966,0.0748,-0.0577,0.0489,-0.0437,0.0731,-0.0418,0.0588,-0.0408,0.03,-0.0282,0.0931,-0.064,0.0648,-0.093,0.0584,-0.0696,0.0493,-0.0671,0.0701,-0.0346,0.0475,-0.0507,0.0407,-0.042,0.0621,-0.0685,0.0532,-0.0499,0.0274,-0.045,0.0385,-0.054,0.0321,-0.0299,0.0719,-0.0719,0.0278,-0.0309,0.0351,-0.0147,0.0232,-0.0217,0.0138,-0.0219,0.1342,-0.0372,0.1112,-0.0691,0.061,-0.0873,0.0659,-0.055,0.0364,-0.0384,0.0218,-0.0225,0.0411,-0.0397,0.1276,-0.1088,0.1168,-0.1386,0.0792,-0.0918,0.0958,-0.0906,0.0402,-0.0656,0.0163,-0.0252,0.0206,-0.0181,0.0107,-0.0127,0.0112,-0.008,0.0075,-0.005,0.0059,-0.0041,0.006,-0.004,0.0046,-0.0056,0.0036,-0.0039,0.0031,-0.003,0.0045,-0.0026,0.0033,-0.0026,0.0029,-0.0018,0.0025,-0.0016,0.0841,-0.0682,0.0778,-0.0921,0.0558,-0.0794,0.0453,-0.0563,0.0424,-0.0798,0.0325,-0.0529,0.0309,-0.0462,0.0492,-0.0601,0.0733,-0.0473,0.0473,-0.0354,0.0408,-0.0293,0.0437,-0.0368,0.0157,-0.0384,0.0169,-0.0135,0.0662,-0.0607,0.0335,-0.055,0.0366,-0.0476,0.0513,-0.0593,0.0569,-0.043,0.0709,-0.0617,0.0593,-0.0761,0.0568,-0.0944,0.0322,-0.0569,0.0444,-0.0338,0.0493,-0.0987,0.0834,-0.105,0.0412,-0.0973,0.0723,-0.0822,0.0699,-0.0748,0.0915,-0.074,0.0425,-0.0681,0.0668,-0.066,0.0761,-0.0523,0.0375,-0.0502,0.0906,-0.084,0.0787,-0.1207,0.0314,-0.0803,0.046,-0.0679,0.0536,-0.1066,0.0495,-0.0804,0.0567,-0.0706,0.0572,-0.0924,0.0471,-0.0544,0.0387,-0.0543,0.05,-0.0354,0.0483,-0.0337,0.083,-0.0788,0.1108,-0.0297,0.1231,-0.1165,0.0583,-0.0546,0.0901,-0.0878,0.0643,-0.0705,0.0666,-0.0342,0.0759,-0.0758,0.0782,-0.0376,0.0756,-0.085,0.092,-0.0631,0.0663,-0.0806,0.0534,-0.048,0.0512,-0.0636,0.0814,-0.0483,0.0284,-0.0826,0.055,-0.0628,0.0711,0,0.0376,-0.047,0.0361,-0.0296,0.0339,-0.0298,0.0309,-0.0411,0.0711,-0.0663,0.0358,-0.0736,0.0492,-0.0441,0.0613,-0.0919,0.0599,-0.0368,0.0799,-0.0536,0.1052,-0.1129,0.0501,-0.0687,0.0499,-0.0242,0.038,-0.036,0.0772,-0.132,0.0619,-0.0441,0.0421,-0.0541,0.0354,-0.0429,0.0333,-0.0663,0.0578,-0.0431,0.0498,-0.033,0.0401,-0.0196,0.0375,-0.0501,0.0494,-0.0522,0.0601,-0.0595,0.039,-0.0338,0.0308,-0.0298,0.0576,-0.0508,0.0533,-0.0722,0.032,-0.0246,0.0525,-0.0632,0.0656,-0.0553,0.0193,-0.0534,0.0516,-0.0341,0.0454,-0.0671,0.0279,-0.0309,0.0557,-0.0705,0.0749,-0.0675,0.0266,-0.0338,0.0324,-0.023,0.035,-0.0337,0.0424,-0.0437,0.0379,-0.0215,0.05,-0.0697,0.0867,-0.0653,0.0684,-0.06,0.0526,-0.0604,0.0534,-0.045,0.0457,-0.0249,0.0457,-0.0351,0.0778,-0.1045,0.0452,-0.1057,0.0707,-0.0741,0.02,-0.0131,0.0127,-0.0341,0.0103,-0.0153,0.1202,-0.0529,0.1218,-0.069,0.0855,-0.0535,0.0719,-0.0681,0.0586,-0.0483,0.0014,-0.0756,0.0524,-0.0728,0.0518,-0.0448,0.051,-0.0287,0.0321,-0.0268,0.024,-0.0267,0.1127,-0.0655,0.0613,-0.0554,0.0497,-0.0391,0.0584,-0.0818,0.0448,-0.069,0.0537,-0.0616,0.0103,-0.0595,0.0653,-0.0525,0.0604,-0.0342,0.0427,-0.0445,0.0534,-0.0384,0.0461,-0.0175,0.0345,-0.0279,0.0741,-0.0859,0.0223,-0.1057,0.0954,-0.0628,0.0649,-0.0693,0.0528,-0.0411,0.0965,-0.0794,0.0838,-0.054,0.0579,-0.0477,0.063,-0.0704,0.0396,-0.051,0.0809,-0.1468,0.0447,-0.0473,0.0281,-0.0167,0.0345,-0.0186,0.0368,-0.0285,0.016,-0.0161,0.0434,-0.0193,0.1049,-0.0834,0.0357,-0.0456,0.0213,-0.0622,0.0506,-0.0372,0.0365,-0.0372,0.0616,-0.0556,0.151,-0.0709,0.0746,-0.1006,0.0715,-0.0863,0.0461,-0.0368,0.0225,-0.0184,0.0173,-0.0173,0.0417,-0.0246,0.1363,-0.1071,0.0388,-0.0867,0.0494,-0.0185,0.0535,-0.0467,0.0878,-0.0451,0.0354,-0.0559,0.0492,-0.0513,0.03,-0.0572,0.0649,-0.0291,0.0361,-0.0364,0.053,-0.0833,0.1085,-0.0899,0.0589,-0.095,0.0815,-0.0573,0.0618,-0.0584,0.0823,-0.0511,0.0194,-0.0694,0.0796,-0.07,0.0648,-0.0699,0.0406,-0.0632,0.0837,-0.0732,0.041,-0.0459,0.0369,-0.0248,0.0715,-0.0423,0.0417,-0.0399,0.0328,-0.0571,0.0858,-0.06,0.0683,-0.087,0.0462,-0.0447,0.0461,-0.0681,0.0755,-0.069,0.0593,-0.0435,0.0032,-0.0771,0.0896,-0.0927,0.0239,-0.0411,0.0229,-0.0203,0.0092,-0.033,0.0307,-0.0228,0.0122,-0.0098,0.0998,-0.0309,0.0816,-0.0834,0.0767,-0.0968,0.0644,-0.0821,0.0414,-0.0811,0.03,-0.0592,0.0855,-0.0415,0.0846,-0.066,0.1514,-0.0722,0.1674,-0.058,0.0971,-0.074,0.0386,-0.0437,0.0213,-0.0205,0.1732,-0.0381,0.085,-0.0803,0.098,-0.1702,0.1098,-0.0971,0.0823,-0.0852,0.0885,-0.0794,0.0705,-0.0561,0.0508,-0.0399,0.0349,-0.0373,0.0357,-0.04,0.045,-0.0542,0.1234,-0.1141,0.0682,-0.047,0.0825,-0.0801,0.0559,-0.0897,0.0592,-0.1021,0.0651,-0.068,0.0846,-0.0516,0.082,-0.0351,0.04,-0.0608,0.0563,-0.0314,0.0291,-0.03,0.0195,-0.0192,0.0571,-0.0404,0.1082,-0.0476,0.0224,-0.046,0.0156,-0.0565,0.1237,-0.0611,0.0885,-0.0728,0.0937,-0.0849,0.1048,-0.0815,0.1133,-0.0733,0.076,-0.0724,0.0789,-0.0669,0.0514,-0.0449,0.047,-0.0729,0.042,-0.0384,0.0561,-0.0605,0.0512,-0.0628,0.0746,-0.0408,0.0662,-0.0612,0.0758,-0.0831,0.0816,-0.0559,0.0272,-0.0462,0.0763,-0.0321,0.0575,-0.0603,0.0597,-0.0211,0.0596,-0.0975,0.0877,-0.0693,0.0605,-0.0992,0.0884,-0.0599,0.1139,-0.1333,0.1232,-0.0737,0.0945,-0.0846,0.0781,-0.0546,0.0624,-0.0737,0.0593,-0.0728,0.0907,-0.0818,0.0907,-0.0783,0.0426,-0.0775,0.0841,-0.0913,0.096,-0.1149,0.0871,-0.0282,0.0479,-0.058,0.0567,-0.0607,0.0118,-0.0171,0.0121,-0.0117,0.0985,-0.1386,0.0601,-0.0902,0.0832,-0.0897,0.0867,-0.0687,0.0846,-0.0464,0.0613,-0.0458,0.0501,-0.0679,0.0617,-0.0727,0.0529,-0.0419,0.0419,-0.0202,0.0372,-0.1283,0.0645,-0.0621,0.0701,-0.0675,0.0632,-0.068,0.0594,-0.0736,0.0418,-0.0441,0.0515,-0.0584,0.0604,-0.0348,0.0426,-0.054,0.0422,-0.0642,0.0719,-0.1023,0.0734,-0.0324,0.0529,-0.0357,0.0327,-0.0244,0.0331,-0.0269,0.0139,-0.0402,0.019,-0.0396,0.0297,-0.0205,0.0236,-0.0217,0.0221,-0.0177,0.0479,-0.0387,0.0542,-0.0496,0.0348,-0.0515,0.0481,-0.0466,0.0138,-0.0207,0.032,-0.0246,0.0319,-0.0259,0.0268,-0.0154,0.0194,-0.03,0.0496,-0.0273,0.0493,-0.032,0.035,-0.0493,0.0192,-0.0397,0.0272,-0.038,0.0401,-0.0391,0.0584,-0.0631,0.0597,-0.0439,0.0497,-0.0431,0.0386,-0.0258,0.0254,-0.0289,0.0234,-0.0322,0.0382,-0.0351,0.024,-0.0302,0.0564,-0.0589,0.0564,-0.0349,0.0361,-0.0629,0.0413,-0.0353,0.0285,-0.0219,0.0339,-0.0405,0.0334,-0.0309,0.0241,-0.0225,0.0215,-0.0392,0.0262,-0.0373,0.05,-0.0382,0.0522,-0.048,0.0485,-0.0485,0.0561,-0.035,0.0251,-0.0643,0.0612,-0.038,0.0581,-0.0815,0.0484,-0.0403,0.021,-0.0349,0.0411,-0.0228,0.0435,-0.0768,0.0628,-0.0354,0.0347,-0.0529,0.0444,-0.0581,0.0276,-0.0621,0.0271,-0.0324,0.0738,-0.0413,0.0714,-0.0425,0.0604,-0.0624,0.047,-0.0519,0.0621,-0.0596,0.0632,-0.0764,0.0538,-0.064,0.0965,-0.0664,0.0613,-0.0785,0.0511,-0.0785,0.0496,-0.0835,0.0558,-0.0415,0.044,-0.0328,0.0298,-0.0583,0.0629,-0.0575,0.0654,-0.0662,0.0662,-0.0377,0.0748,-0.0771,0.1002,-0.035,0.0996,-0.0711,0.0853,-0.0614,0.0727,-0.0849,0.0808,-0.0431,0.0533,-0.0613,0.0923,-0.0514,0.1251,-0.0757,0.0688,-0.0551,0.1095,-0.0854,0.1288,-0.1627,0.1221,-0.0664,0.1037,-0.115,0.078,-0.0564,0.1074,-0.0753,0.0851,-0.0797,0.1005,-0.0804,0.048,-0.0748,0.1249,-0.0792,0.0983,-0.0966,0.1066,-0.106,0.1325,-0.1016,0.1204,-0.0846,0.1248,-0.0758,0.0738,-0.0946,0.1134,-0.0719,0.1143,-0.0915,0.0789,-0.0583,0.0986,-0.1099,0.0904,-0.0632,0.1377,-0.1341,0.1308,-0.1103,0.0653,-0.087,0.1028,-0.0621,0.0901,-0.0629,0.0329,-0.0664,0.1109,-0.142,0.0399,-0.0609,0.0428,-0.0679,0.0552,-0.0562,0.0554,-0.0556,0.0588,-0.0334,0.0444,-0.0313,0.1202,-0.0802,0.0161,-0.0104,0.013,-0.0063,0.1018,-0.1476,0.0893,-0.1247,0.0611,-0.027,0.0514,-0.0257,0.0296,-0.0221,0.0545,-0.0261,0.0385,-0.0575,0.0169,-0.0511,0.0324,-0.0233,0.0469,-0.0072,0.1297,-0.1389,0.1458,-0.1443,0.053,-0.0615,0.0494,-0.0793,0.0263,-0.022,0.0177,-0.0147,0.0156,-0.0067,0.1605,-0.1581,0.0643,-0.0879,0.0614,-0.0863,0.0277,-0.049,0.042,-0.0229,0.0474,-0.0269,0.0317,-0.0229,0.0975,-0.0633,0.0794,-0.0582,0.0995,-0.088,0.0392,-0.0589,0.0229,-0.0253,0.0172,-0.0214,0.0172,-0.0103,0.1617,-0.1116,0.0761,-0.0942,0.0534,-0.0994,0.0858,-0.0826,0.0514,-0.0629,0.0795,-0.0995,0.0487,-0.0785,0.0837,-0.0588,0.0478,-0.0655,0.0469,-0.0292,0.1227,-0.1057,0.0637,-0.0865,0.0713,-0.1097,0.1112,-0.0916,0.0658,-0.0687,0.091,-0.0646,0.0142,-0.0591,0.0585,-0.0866,0.0808,-0.0655,0.0937,-0.0626,0.0538,-0.0696,0.0358,-0.0323,0.0267,-0.0129,0.0923,-0.0557,0.0937,-0.0782,0.097,-0.142,0.0595,-0.075,0.1067,-0.1121,0.1085,-0.136,0.1006,-0.0639,0.0705,-0.0738,0.0556,-0.0634,0.0744,-0.0448,0.0536,-0.064,0.1441,-0.0836,0.0776,-0.0668,0.0421,-0.0253,0.0302,-0.0291,0.0245,-0.0223,0.0312,-0.0172,0.0802,-0.0488,0.0551,-0.0724,0.0505,-0.0389,0.03,-0.0288,0.0292,-0.0421,0.021,-0.0198,0.0208,-0.0354,0.1707,-0.1063,0.0816,-0.1109,0.0934,-0.0607,0.0936,-0.0741,0.0225,-0.0196,0.0191,-0.0164,0.1112,-0.0664,0.1342,-0.1438,0.093,-0.1232,0.0415,-0.0853,0.0662,-0.0761,0.0687,-0.0384,0.027,-0.0553,0.0182,-0.0128,0.028,-0.0379,0.0107,-0.021,0.0265,-0.0833,0.0657,-0.1274,0.0762,-0.0805,0.0809,-0.0403,0.0606,-0.1194,0.0932,-0.0428,0.1101,-0.0919,0.0417,-0.0373,0.0427,-0.0517,0.0463,-0.0396,0.0657,-0.0761,0.0793,-0.0759,0.0236,-0.0295,0.0209,-0.023,0.0961,-0.1045,0.0384,-0.0964,0.1053,-0.0215,0.0945,-0.0591,0.0764,-0.0836,0.0687,-0.0668,0.0623,-0.0377,0.0802,-0.0399,0.0619,-0.0815,0.1,-0.0686,0.102,-0.095,0.0721,-0.0651,0.0645,-0.0445,0.0219,-0.021,0.0277,-0.0313,0.0179,-0.0167,0.0169,-0.0479,0.0996,-0.0663,0.0701,-0.0742,0.0607,-0.0724,0.0571,-0.0425,0.0448,-0.0632,0.0526,-0.0319,0.1031,-0.1586,0.0631,-0.144,0.0525,-0.0679,0.0935,-0.0413,0.0294,-0.0526,0.0118,-0.0155,0.0154,-0.014,0.1178,-0.1098,0.0777,-0.0914,0.127,-0.0727,0.0425,-0.0371,0.0383,-0.0602,0.0607,-0.0548,0.0811,-0.0891,0.0545,-0.0295,0.0287,-0.0157,0.0254,-0.0132,0.101,-0.0798,0.0974,-0.0919,0.0945,-0.0895,0.085,-0.0301,0.0496,-0.0836,0.0673,-0.0833,0.0857,-0.0373,0.098,-0.0797,0.0468,-0.0271,0.021,-0.0468,0.048,-0.0577,0.0191,-0.0276,0.0155,-0.0258,0.0864,-0.0749,0.0958,-0.093,0.0707,-0.0448,0.0472,-0.0738,0.09,-0.0766,0.125,-0.0887,0.0928,-0.0559,0.0904,-0.1031,0.0686,-0.1036,0.0268,-0.0552,0.1007,-0.0538,0.0328,-0.0419,0.0528,-0.0394,0.0733,-0.0342,0.0839,-0.0578,0.1027,-0.0712,0.0901,-0.046,0.0648,-0.0272,0.071,-0.0955,0.0532,-0.0556,0.0891,-0.0416,0.0841,-0.0221,0.0447,-0.0368,0.02,-0.0622,0.0568,-0.0423,0.0603,-0.0299,0.0506,-0.0279,0.0954,-0.0952,0.0377,-0.0741,0.0985,-0.064,0.049,-0.0381,0.0472,-0.0357,0.009,-0.0773,0.052,-0.0386,0.0884,-0.0446,0.0255,-0.0956,0.051,-0.0598,0.1228,-0.1574,0.0757,-0.149,0.0394,-0.0621,0.0397,-0.0433,0.0115,-0.0181,0.0123,-0.0092,0.0099,-0.0085,0.1067,-0.084,0.0984,-0.0803,0.0518,-0.0735,0.0427,-0.0306,0.0229,-0.0361,0.0477,-0.0425,0.0518,-0.0543,0.1639,-0.1203,0.0942,-0.0951,0.0732,-0.0942,0.0366,-0.0537,0.0199,-0.0199,0.0139,-0.0093,0.0311,-0.0329,0.0216,-0.0504,0.0255,-0.0184,0.0088,-0.009,0.0144,-0.0131,0.0096,-0.0065,0.0058,-0.0038,0.0227,-0.0342,0.0377,-0.0224,0.0224,-0.0154,0.0084,-0.0067,0.005,-0.0047,0.0068,-0.007,0.0097,-0.0072,0.0837,-0.1027,0.0919,-0.0594,0.0897,-0.0796,0.0914,-0.1232,0.0488,-0.0695,0.0724,-0.0538,0.0447,-0.0575,0.0803,-0.0767,0.0574,-0.053,0.0807,-0.0569,0.1493,-0.1466,0.115,-0.0831,0.091,-0.0688,0.0925,-0.0626,0.1208,-0.0842,0.0918,-0.0711,0.0639,-0.0524,0.0455,-0.018,0.0686,-0.0444,0.0765,-0.0601,0.139,-0.0484,0.1333,-0.1171,0.0967,-0.1135,0.0852,-0.1019,0.0208,-0.0294,0.015,-0.0168,0.0214,-0.05,0.1469,-0.1044,0.0774,-0.0837,0.0716,-0.0473,0.048,-0.0408,0.0398,-0.0287,0.0372,-0.0272,0.0451,-0.0261,0.1782,-0.1238,0.0753,-0.0988,0.0687,-0.0591,0.0305,-0.019,0.0181,-0.0131,0.0149,-0.0138,0.0321,-0.0104,0.0287,-0.01,0.0058,-0.0082,0.0083,-0.006,0.0268,-0.0218,0.0072,-0.0082,0.0053,-0.0068,0.0411,-0.0647,0.0161,-0.0274,0.0081,-0.0111,0.0149,-0.0217,0.033,-0.0262,0.0277,-0.028,0.0213,-0.0289,0.0585,-0.0772,0.1011,-0.077,0.099,-0.0751,0.0886,-0.0736,0.0544,-0.0606,0.0553,-0.0665,0.0414,-0.0965,0.0973,-0.0888,0.0651,-0.0745,0.1149,-0.118,0.1085,-0.0914,0.1063,-0.0991,0.0561,-0.0711,0.0783,-0.0751,0.1133,-0.0694,0.0505,-0.0559,0.0827,-0.0676,0.0856,0,0.0745,-0.0269,0.1061,-0.0502,0.1294,-0.0946,0.043,-0.1153,0.0654,-0.0561,0.03,-0.0505,0.0208,-0.0502,0.0262,-0.0236,0.0142,-0.1129,0.108,-0.0775,0.1099,-0.1064,0.0486,-0.0438,0.0332,-0.0681,0.0331,-0.0271,0.0805,-0.0534,0.1443,-0.1007,0.1725,-0.0987,0.0945,-0.0712,0.0393,-0.0121,0.0163,-0.0179,0.0089,-0.0142,0.0144,-0.0123,0.011,-0.0158,0.007,-0.0037,0.0041,-0.0063,0.0208,-0.0172,0.0057,-0.0055,0.0026,-0.0043,0.0303,-0.0238,0.0044,-0.0075,0.0044,-0.0028,0.0052,-0.008,0.0107,-0.0096,0.0078,-0.0068,0.0312,-0.0062,0.0628,-0.0462,0.0393,-0.0408,0.0465,-0.0538,0.0472,-0.0608,0.0375,-0.0655,0.0251,-0.0377,0.014,-0.0367,0.1706,-0.1053,0.0458,-0.0199,0.02,-0.0226,0.0431,-0.0924,0.0702,-0.0713,0.0999,-0.0828,0.0463,-0.0473,0.0301,-0.0399,0.0308,-0.047,0.0464,-0.03,0.0806,-0.0763,0.0419,-0.0348,0.0375,-0.0137,0.0515,-0.0109,0.0426,-0.0608,0.0592,-0.0902,0.0425,-0.0525,0.0157,-0.0296,0.0076,-0.0119,0.0666,-0.1704,0.2134,-0.1717,0.0652,-0.0998,0.0658,-0.0718,0.0679,-0.0334,0.0673,-0.0382,0.0504,-0.0458,0.0681,-0.1054,0.104,-0.1199,0.1459,-0.148,0.0695,-0.1088,0.0275,-0.055,0.0202,-0.0174,0.0208,-0.011,0.0609,-0.0594,0.0173,-0.0139,0.0071,-0.0147,0.0078,-0.0052,0.0148,-0.0116,0.0086,-0.0055,0.0041,-0.0483,0.0202,-0.0668,0.0125,-0.0101,0.0054,-0.0062,0.0125,-0.0072,0.0048,-0.0103,0.0112,-0.0129,0.1483,-0.1396,0.1506,-0.0615,0.0739,-0.0929,0.0321,-0.0391,0.0494,-0.0371,0.0368,-0.0512,0.0325,-0.0089,0.0876,-0.1079,0.0719,-0.0976,0.029,-0.0216,0.0393,-0.0202,0.1195,-0.152,0.1134,-0.165,0.0827,-0.1129,0.1077,-0.0831,0.095,-0.0837,0.0674,-0.0598,0.0451,-0.051,0.0323,-0.0377,0.0482,-0.0459,0.0394,-0.0614,0.0398,-0.0746,0.1408,-0.0937,0.1348,-0.1061,0.0535,-0.0962,0.02,-0.0369,0.0208,-0.0185,0.1134,-0.0812,0.068,-0.0752,0.0752,-0.0693,0.0567,-0.0367,0.0273,-0.0531,0.0409,-0.0187,0.0552,-0.0532,0.1235,-0.1005,0.1717,-0.1607,0.1153,-0.144,0.0546,-0.113,0.0315,-0.0205,0.016,-0.0183,0.0112,-0.0319,0.0523,-0.0395,0.0207,-0.0177,0.0144,-0.0119,0.0195,-0.0206,0.0103,-0.0112,0.0087,-0.0054,0.0476,-0.0424,0.0176,-0.0329,0.0046,-0.0052,0.0099,-0.0086,0.0227,-0.0143,0.0196,-0.0179,0.0097,-0.0098,0.0714,-0.1175,0.0684,-0.0692,0.0674,-0.0314,0.0286,-0.0451,0.0292,-0.0319,0.0187,-0.016,0.0225,-0.0394,0.1045,-0.0887,0.035,-0.0441,0.013,-0.0154,0.1401,-0.0626,0.1423,-0.0623,0.1147,-0.0975,0.1156,-0.0618,0.0488,-0.064,0.0386,-0.0736,0.0379,-0.0373,0.0259,-0.0638,0.0517,-0.0407,0.0467,-0.0235,0.0912,-0.0738,0.1093,-0.1343,0.1307,-0.1369,0.0781,-0.077,0.0423,-0.0349,0.0256,-0.0182,0.056,-0.0139,0.0887,-0.1468,0.0835,-0.1034,0.0409,-0.065,0.0462,-0.0295,0.0238,-0.0364,0.0407,-0.0417,0.086,-0.0943,0.1062,-0.1381,0.0429,-0.0506,0.1025,-0.0763,0.0387,-0.0457,0.0183,-0.0175,0.0121,-0.0154,0.0774,-0.0148,0.0307,-0.0414,0.0099,-0.0134,0.0135,-0.0134,0.0113,-0.0072,0.011,-0.0094,0.0067,-0.0056,0.0299,-0.0534,0.0208,-0.0195,0.0134,-0.0083,0.0059,-0.0099,0.0165,-0.0122,0.0065,-0.0133,0.006,-0.0058,0.0908,-0.0841,0.0939,-0.0619,0.0629,-0.0601,0.0296,-0.055,0.0367,-0.0338,0.0359,-0.0443,0.0321,-0.016,0.0598,-0.1436,0.0567,-0.0573,0.0296,-0.0304,0.11,-0.0358,0.11,-0.0402,0.0228,-0.0559,0.025,-0.069,0.0095,-0.071,0.0599,-0.0953,0.078,-0.0923,0.0762,-0.0417,0.0458,-0.0275,0.0342,-0.0102,0.0669,-0.0464,0.0738,-0.094,0.1066,-0.0992,0.0613,-0.0636,0.0505,-0.0504,0.0243,-0.0231,0.0519,-0.0211,0.0956,-0.1029,0.1355,-0.1042,0.0937,-0.0998,0.0563,-0.0608,0.0527,-0.0323,0.0203,-0.0394,0.1472,-0.0572,0.1182,-0.0812,0.0984,-0.106,0.0706,-0.0763,0.0531,-0.0366,0.0229,-0.0181,0.0136,-0.0172,0.0388,-0.0446,0.0137,-0.0149,0.0121,-0.0136,0.007,-0.01,0.0105,-0.0134,0.0054,-0.0075,0.0032,-0.0027,0.0367,-0.0136,0.0096,-0.0086,0.0046,-0.0079,0.0147,-0.0055,0.0115,-0.0067,0.0067,-0.0083,0.01,-0.0064,0.0935,-0.083,0.0645,-0.0699,0.063,-0.0585,0.0739,-0.0455,0.0413,-0.0599,0.0358,-0.0228,0.0375,-0.0422,0.1055,-0.078,0.0415,-0.0178,0.0302,-0.0166,0.0878,-0.1059,0.0523,-0.1012,0.0641,-0.0649,0.1065,-0.0727,0.0696,-0.0645,0.0582,-0.0647,0.0419,-0.0383,0.118,-0.0434,0.0769,-0.0518,0.016,-0.0279,0.0714,-0.0654,0.0793,-0.0676,0.1057,-0.064,0.0692,-0.0703,0.0277,-0.0439,0.0213,-0.0139,0.0186,-0.0992,0.0883,-0.1128,0.043,-0.0583,0.0337,-0.0333,0.0253,-0.0189,0.0156,-0.0175,0.0194,-0.0241,0.1097,-0.0963,0.1305,-0.1416,0.0919,-0.144,0.1131,-0.0987,0.0809,-0.0558,0.0246,-0.0185,0.0165,-0.0203,0.0157,-0.0103,0.0122,-0.0106,0.0111,-0.0097,0.0069,-0.0053,0.0097,-0.0052,0.0073,-0.0046,0.0047,-0.0054,0.0034,-0.0025,0.0039,-0.0037,0.002,-0.0031,0.0015,-0.0026,0.0019,-0.0017,0.0019,-0.0013,0.001,-0.0007,0.0014,-0.0009,0.0012,-0.001,0.0012,-0.0006,0.0009,-0.0009,0.0006,-0.0009,0.0004,-0.0001]";
        //    //    hmyAnimation.Attributes.Add("data-peaks", peaks);
        //    //    hmyAnimation.Attributes.Add("class", "ws-waveform__layer veryfirst");
        //    //    hmyAnimation.Attributes.Add("data-key", hSongID.Value.ToString());
        //    //    hmyAnimation.Attributes.Add("data-file", "http://testapp.hitlicense.com/Hit_Songs/" + hSongID.Value.ToString()+".mp3");
        //    //    //hmyAnimation.Attributes.Add("data-peaks",dt.Rows[0]["peaks"].ToString());
        //    //}
        //}




        private void FetchData(int nstartIndex, int pageSize)
        {
            string userId = Session["userId"].ToString();
           
            string sql = "";
            int st = ((nstartIndex - 1) * pageSize) + 1;
            int lst = (nstartIndex * pageSize);
            string albumId = Page.RouteData.Values["albumId"].ToString();

            string filter = (string)(Session["filter"]);

   
            if (filter == "all")
            {
                sql = "SELECT *,song_peaks.peaks as peakval from  (SELECT *,ROW_NUMBER()  OVER(ORDER BY id )  AS RowRank " +
              " from Songs Where status<>10 and uploader='" + userId + "' AND  AddtoProfile='Y') AS songtable " +
              " left join song_peaks on song_peaks.songId=songtable.id where RowRank between " + st + " and " + lst;

            }
            if (filter == "featured")
            {
                sql = "SELECT *,song_peaks.peaks as peakval from Songs left join song_peaks on song_peaks.songId=Songs.id Where Songs.status<>10 and Songs.uploader='" + userId + "' AND Songs.Featured=1  AND Songs.AddtoProfile='Y' ";

              //  sql = "SELECT *,song_peaks.peaks as peakval from  (SELECT *,ROW_NUMBER()  OVER(ORDER BY id )  AS RowRank " +
           //" from Songs Where status<>10 and uploader='" + userId + "' AND Featured=1  AND AddtoProfile='Y') AS songtable " +
          // " left join song_peaks on song_peaks.songId=songtable.id where RowRank between " + st + " and " + lst;
            }
            if (filter == "playlists" && albumId != "0")
            {
                sql = "SELECT *,song_peaks.peaks as peakval from  (SELECT *,ROW_NUMBER()  OVER(ORDER BY PlayListHeaderID )  AS RowRank from PlayList " +
    " Where PlayListHeaderID=" + albumId + " ) AS songtable  left join Songs on Songs.id=songtable.SongID left join song_peaks on song_peaks.songId=songtable.SongID where Songs.AddtoProfile='Y' AND Songs.uploader='" + userId + "' AND Songs.status<>10 AND RowRank between " + st + " and " + lst;
            }
            DataTable dt = DBUtils.ExecuteQuery(sql);

            this.SongTable = dt;
            if (this.SongTable.Rows.Count == 0)
            {
                if (this.CurrentPageId == null)
                    this.CurrentPageId = "1";

                dt = DBUtils.ExecuteQuery(sql);
                this.SongTable = dt;
                this.CurrentPageId = (int.Parse(this.CurrentPageId) - 1).ToString();
            }

            using (this.SongTable)
            {

                if (SongTable.Rows.Count > 0)
                {
                    pnlMySong.Visible = true;
                    RtMysongs.DataSource = null;
                    RtMysongs.DataSource = SongTable;
                    RtMysongs.DataBind();
                }
                else {
                    pnlMySong.Visible = false;
                    
                }
                if (filter != "featured")
                {
                    this.LinkButtonsForeColorAssign();
                    if (IsPostBack) return;
                    if (this.CurrentPageId == null)
                    {
                        CreatePagingControl();

                        this.LinkButtonsForeColorAssign();
                    }
                    else
                    {
                        CreatePagingControl();
                        this.LinkButtonsForeColorAssign();
                    }
                }



            }


            //string sql = "SELECT ,song_peaks.peaks as peakval from  (SELECT ,ROW_NUMBER()  OVER(ORDER BY id )  AS RowRank " +
            //                 " from Songs Where status<>10 and  uploader='" + userId + "' AND  AddtoProfile='Y') AS songtable " +
            //                 " left join song_peaks on song_peaks.songId=songtable.id where song_peaks.haswave=1 and RowRank between " + nstartIndex + " and " + (nstartIndex + pageSize);
            //DataTable dt = DBUtils.ExecuteQuery(sql);
            //RtMysongs.DataSource = this.SongTable;
            //RtMysongs.DataBind();


        }

        private void CreatePagingControl()
        {
            int pagesize = 5;
            if (Session["filter"] == "all")
            {
                pagesize = 10;
            }
            if (Session["filter"] == "featured")
            {
                pagesize = 5;
            }
            if (Session["filter"] == "playlists")
            {
                pagesize = 10;
            }
            for (double i = 0; i < (RowCount / pagesize) + 1; i++)
            {

                var lnkb = new LinkButton();
                lnkb.Click += new EventHandler(lnk_Click);
                lnkb.ID = "lnkPageb" + (i + 1).ToString(CultureInfo.InvariantCulture);
                lnkb.Text = (i + 1).ToString(CultureInfo.InvariantCulture);
                var plsHolderb = (PlaceHolder)this.FindControl("plcPagingb");

                // plsHolder.Controls.Add(lnk);
                plsHolderb.Controls.Add(lnkb);
                if (RowCount == pagesize) break;

                float fRemainRecord = (float.Parse(RowCount.ToString()) / pagesize);
                if ((i + 1) == fRemainRecord) break;

            }

        }

        private void lnk_Click(object sender, EventArgs e)
        {
            int pagesize = 5;
            if (Session["filter"] == "all")
            {
                pagesize = 10;
            }
            if (Session["filter"] == "featured")
            {
                pagesize = 5;
            }
            if (Session["filter"] == "playlists")
            {
                pagesize = 10;
            }
            //string userId = Request.QueryString["userID"].ToString();
            //string userId = Page.RouteData.Values["Id"].ToString();
            var lnk = sender as LinkButton;
            if (lnk == null) return;
            this.LinkButtonsForColorReset();
            //lnk.CssClass = "current";
            this.CurrentPageId = lnk.Text;
            var currentPage = int.Parse(lnk.Text);
            var take = (currentPage - 1) * pagesize;
            var skip = currentPage == 1 ? 0 : take - pagesize;
            take = take + 1;

            try
            {

                FetchData(int.Parse(this.CurrentPageId), pagesize);
            }
            catch (Exception ex)
            {
                throw ex;
                //Response.Redirect("../Default.aspx");
            }
        }

        private void LinkButtonsForColorReset()
        {
            //  var plsHolder = (PlaceHolder)this.FindControl("plcPaging");
            //  foreach (var lnk in (from Control c in plsHolder.Controls where c.GetType() == typeof(LinkButton) select c).Cast<LinkButton>())
            //   {
            //      lnk.CssClass = "";
            //  }

            var plsHolderb = (PlaceHolder)this.FindControl("plcPagingb");
            foreach (var lnk in (from Control c in plsHolderb.Controls where c.GetType() == typeof(LinkButton) select c).Cast<LinkButton>())
            {
                lnk.CssClass = "";
            }

        }

        private void LinkButtonsForeColorAssign()
        {
            //    var plsHolderUp = (PlaceHolder)this.FindControl("plcPaging");
            //
            //    foreach (var lnk in (from Control c in plsHolderUp.Controls where c.GetType() == typeof(LinkButton) select c).Cast<LinkButton>().Where(lnk => lnk.Text == this.CurrentPageId))
            //    {
            //        lnk.CssClass = "current";
            //        break;
            //    }

            var plsHolderDwn = (PlaceHolder)this.FindControl("plcPagingb");
            foreach (var lnk in (from Control c in plsHolderDwn.Controls where c.GetType() == typeof(LinkButton) select c).Cast<LinkButton>().Where(lnk => lnk.Text == this.CurrentPageId))
            {
                lnk.CssClass = "current";
                break;
            }
        }



        #endregion

       

    }
}