using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SongCatelogApp.MPM_Data
{
    public class ProfileServices
    {
        private SongCatalog.MPM.Data.DatabaseUtils DBUtils = new SongCatalog.MPM.Data.DatabaseUtils();


        public DataTable getProfileReviews(string userId, string pageNo)
        {
            //getting profile news
            int recordsPerPage = 2;
            int startr = ((Convert.ToInt32(pageNo) - 1) * recordsPerPage) + 1;
            int lastr = ((Convert.ToInt32(pageNo)) * recordsPerPage);
            //string sql = "SELECT a.* FROM (SELECT ROW_NUMBER() OVER (ORDER BY  ReviewsID ASC) AS RowNum, * FROM Profile_Reviews  WHERE UserId='" + userId + "') a  WHERE UserId='" + userId + "' AND a.RowNum BETWEEN " + startr + " AND " + lastr;
            string sql = "SELECT  * FROM Profile_Reviews  WHERE UserId='" + userId + "' ORDER BY  ReviewsID ASC";
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }
        public DataTable GetSongs(string userId, string pageNo)
        {
            //getting profile news
            int recordsPerPage = 2;
            int startr = ((Convert.ToInt32(pageNo) - 1) * recordsPerPage) + 1;
            int lastr = ((Convert.ToInt32(pageNo)) * recordsPerPage);
            string sql = "SELECT a.* FROM (SELECT ROW_NUMBER() OVER (ORDER BY  ReviewsID ASC) AS RowNum, * FROM Profile_Reviews  WHERE UserId='" + userId + "') a  WHERE UserId='" + userId + "' AND a.RowNum BETWEEN " + startr + " AND " + lastr;

            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }
        
        public string getUserIdUsingScreenName(string screenName)
        {
            string userId = "";
            string sql = "SELECT * from PersonalInfo where ProfileURL='" + screenName + "'";
            DataTable dt = DBUtils.ExecuteQuery(sql);
           if(dt.Rows.Count>0){
               userId = dt.Rows[0]["UserID"].ToString();
           }
           return userId;
        }
        public string getUserEmailUsingScreenName(string screenName)
        {
            string email = "";
            //string sql = "SELECT * from PersonalInfo where ProfileURL='" + screenName + "'";
            string sql = "SELECT PersonalInfo.email as pemail,mpm_Users.email as userEmail from PersonalInfo left join mpm_Users on mpm_Users.id=PersonalInfo.UserID where PersonalInfo.ProfileURL='" + screenName + "'";
            DataTable dt = DBUtils.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                email = dt.Rows[0]["pemail"].ToString();
                if (dt.Rows[0]["pemail"].ToString() == "")
                {
                    email = dt.Rows[0]["userEmail"].ToString();
                }
            }
            return email;
        }
        //public string getUserEmailUsingScreenName(string screenName)
        //{
        //    string email = "";
        //    //string sql = "SELECT * from PersonalInfo where ProfileURL='" + screenName + "'";
        //    string sql = "SELECT PersonalInfo.email as pemail,mpm_Users.email as userEmail from PersonalInfo left join mpm_Users on mpm_Users.id=PersonalInfo.UserID where PersonalInfo.ProfileURL='" + screenName + "'";
        //    DataTable dt = DBUtils.ExecuteQuery(sql);
        //   if(dt.Rows.Count>0){
        //       email = dt.Rows[0]["pemail"].ToString();
        //       if (dt.Rows[0]["pemail"].ToString() == null || dt.Rows[0]["pemail"].ToString()=="")
        //       {
        //        email = dt.Rows[0]["userEmail"].ToString();
        //       }
        //   }
        //   return email;
        //}
        
        public int moreCreditsAvailable(string pageNo, string userId)
        {
            int recordsPerPage = 5;
            int lastr = (((Convert.ToInt32(pageNo)) * recordsPerPage)) + 1;
            int finalr = lastr + 1;
            string sql = "SELECT count(*) as rcount FROM (SELECT ROW_NUMBER() OVER (ORDER BY  CreditId ASC) AS RowNum, * FROM Profile_CreditDetails  WHERE UserID='" + userId + "') a  WHERE UserID='" + userId + "' AND a.RowNum BETWEEN " + lastr + " AND " + finalr;

            DataTable dt = DBUtils.ExecuteQuery(sql);
            return Convert.ToInt32(dt.Rows[0]["rcount"].ToString());
        }

        public int moreReviewsAvailable(string pageNo, string userId)
        {
            int recordsPerPage = 2;
            int lastr = (((Convert.ToInt32(pageNo)) * recordsPerPage)) + 1;
            int finalr = lastr + 1;
            string sql = "SELECT count(*) as rcount FROM (SELECT ROW_NUMBER() OVER (ORDER BY  ReviewsID ASC) AS RowNum, * FROM Profile_Reviews  WHERE UserId='" + userId + "') a  WHERE UserId='" + userId + "' AND a.RowNum BETWEEN " + lastr + " AND " + finalr;

            DataTable dt = DBUtils.ExecuteQuery(sql);
            return Convert.ToInt32(dt.Rows[0]["rcount"].ToString());
        }

                    //check any more data available to display
        public int moreAwardsAvailable(string pageNo, string userId)
        {
            int recordsPerPage = 2;
            int lastr = (((Convert.ToInt32(pageNo)) * recordsPerPage)) + 1;
            int finalr = lastr + 1;
            string sql = "SELECT count(*) as rcount  FROM (SELECT ROW_NUMBER() OVER (ORDER BY  AwardID ASC) AS RowNum, * FROM Profile_Awards  WHERE UserID='" + userId + "') a  WHERE UserID='" + userId + "' AND a.RowNum BETWEEN " + lastr + " AND " + finalr;

            DataTable dt = DBUtils.ExecuteQuery(sql);
            return Convert.ToInt32(dt.Rows[0]["rcount"].ToString());
        }

        //check any more data available to display
        public int moreNewsAvailable(string pageNo,string userId)
        {
            int recordsPerPage = 2;
            int lastr = (((Convert.ToInt32(pageNo)) * recordsPerPage)) + 1;
            int finalr = lastr + 1;
            string sql = "SELECT count(*) as rcount FROM (SELECT ROW_NUMBER() OVER (ORDER BY  NewsID ASC) AS RowNum, * FROM NewsDetails  WHERE UseId='" + userId + "') a  WHERE UseId='" + userId + "' AND a.RowNum BETWEEN " + lastr + " AND " + finalr;

            DataTable dt = DBUtils.ExecuteQuery(sql);
            return Convert.ToInt32(dt.Rows[0]["rcount"].ToString());
        }
  

        public DataTable getProfileNews(string userId,string pageNo)
        {
            //getting profile news
            int recordsPerPage = 2;
            int startr = ((Convert.ToInt32(pageNo) - 1) * recordsPerPage)+1;
            int lastr = ((Convert.ToInt32(pageNo)) * recordsPerPage);
            //string sql = "SELECT a.* FROM (SELECT ROW_NUMBER() OVER (ORDER BY  PublishDate desc) AS RowNum, * FROM NewsDetails  WHERE UseId='" + userId + "') a  WHERE UseId='" + userId + "' AND a.RowNum BETWEEN " + startr + " AND " + lastr;
            string sql = "SELECT  * FROM NewsDetails  WHERE UseId='" + userId + "' ORDER BY  PublishDate desc";
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }


        public DataTable getAllPlaylists(string userId)
        {
            string sql = "SELECT * FROM PlayListHeader WHERE RecStatus='AC' AND UserID='"+userId+"'";
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;
        }

        public DataTable getPhotos(string userId)
        {
            //   string sql = "SELECT * FROM Profile_PhotoVideo WHERE UserID='" + userId + "' AND RecStatus='AC'";
            string sql = "select FileType, FileName, FileUrl,  PrifileVideoPhotoID, On_Off from dbo.Profile_PhotoVideo where RecStatus='AC' and FileType='P' and UserID=" + userId + "  order by OrderID ";
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }
        public DataTable getVideos(string userId)
        {
         //   string sql = "SELECT * FROM Profile_PhotoVideo WHERE UserID='" + userId + "' AND RecStatus='AC'";
            string sql = "select FileType, FileName, FileUrl,  PrifileVideoPhotoID, On_Off from dbo.Profile_PhotoVideo where RecStatus='AC' and FileType='V' and UserID=" + userId + "  order by OrderID ";
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }
        public DataTable getSongsListFeatured(string userId, string pageNo)
        {
            int recordsPerPage = 5;
            int startr = ((Convert.ToInt32(pageNo) - 1) * recordsPerPage) + 1;
            int lastr = ((Convert.ToInt32(pageNo)) * recordsPerPage);
            string sql = "SELECT * from  (SELECT *,ROW_NUMBER()  OVER(ORDER BY id )  AS RowRank " +
                           " from Songs Where status<>10 and uploader='" + userId + "' AND Featured=1  AND AddtoProfile='Y') AS songtable " +
                           "  left join song_peaks on songtable.id = song_peaks.songId  where RowRank between " + startr + " and " + lastr;

            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }


        public int getSongsCount(string userId)
        {

            string sql = "SELECT count(*)  as scount from Songs Where status<>10 and uploader='" + userId + "' AND AddtoProfile='Y'";
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return Convert.ToInt32(dt.Rows[0]["scount"].ToString());

        }
        public DataTable getSongsList(string userId, int pageNo)
        {
            //pageNo = pageNo - 4;
            int recordsPerPage = 5;
            //int startr = ((Convert.ToInt32(pageNo)) * recordsPerPage) + 1;
            //int lastr = ((Convert.ToInt32(pageNo)) * recordsPerPage);

            int startr = ((Convert.ToInt32(pageNo))) + 1;
            int lastr = ((Convert.ToInt32(pageNo)) + recordsPerPage);
            string sql = "SELECT *,song_peaks.peaks as peakval,CASE " +
" WHEN SongImageType = 'S' THEN '/Profile_SongImage/'+SongImage" +
" WHEN SongImageType = 'A' THEN '/Profile_AlbumImage/'+SongImage" +
" WHEN SongImageType = 'U' THEN '/Profile_SongImage/default_cropImg.jpg'" +
" WHEN SongImageType = 'D' THEN '/Profile_SongImage/'+SongImage" +
"  ELSE '/Profile_SongImage/default_cropImg.jpg'" +
"  END as imgpath from  (SELECT *,ROW_NUMBER()  OVER(ORDER BY id )  AS RowRank " +
" from Songs Where status<>10 and uploader='" + userId + "' AND  AddtoProfile='Y') AS songtable " +
" left join song_peaks on song_peaks.songId=songtable.id where RowRank between " + startr + " and " + lastr;

         //   string sql = "SELECT *,song_peaks.peaks as peakVal from  (SELECT *,ROW_NUMBER()  OVER(ORDER BY id )  AS RowRank " +
                           //" from Songs Where status<>10 and uploader='" + userId + "' AND AddtoProfile='Y') AS songtable " +
                           //"  left join song_peaks on songtable.id = song_peaks.songId  where RowRank between " + startr + " and " + lastr;
            
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }
        public DataTable GetSongLyrics(string SongID)
        {
            string sql = "select lyrics from Songs where id=" + SongID;
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }

        public DataTable GetSongMetadataDetails(string SongID)
        {
            string sql = "select  SongID,isnull(SongPemission,1) as SongPemission,Controling, WORKID, ISWC, WRITERS, PUBLISHER, ARTIST, LABLE, RecStatus	from  dbo.View_SongMetaData where SongID=" + SongID;
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }
        public DataTable GetSongDetails(string SongID)
        {
            string sql = "select  songTitle,artist,KeyWord, VocalMix, TEMPO, BPM, FeaturedInstrument from dbo.View_SongMetaData " +
            " left join Profile_SongTempo on Profile_SongTempo.TempoId= View_SongMetaData.TEMPOID "+
            " left join Profile_VocalMix on Profile_VocalMix.VocalMixID=View_SongMetaData.VOCALMIXValue" +
            " where View_SongMetaData.id=" + SongID;
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }

        public string GetSecSongGenreforPopup(string SongID)
        {
            string sql = "select  Genre from dbo.View_UserGenreDetails where UserGenreType=2 AND SongID=" + SongID;
            DataTable dt = DBUtils.ExecuteQuery(sql);
            string genres = "";
            if (dt.Rows.Count > 0)
            {
                for (int g = 0; g < dt.Rows.Count; g++)
                {
                    genres = genres + dt.Rows[g]["Genre"].ToString() + ",";

                }
                genres = genres.Substring(0, genres.Length - 1);
            }
            return genres;
        }
        public string GetSongGenreforPopup(string SongID)
        {
            string sql = "select  Genre from dbo.View_UserGenreDetails where UserGenreType=1 AND SongID=" + SongID;
            DataTable dt = DBUtils.ExecuteQuery(sql);
            string genres = "";
            if (dt.Rows.Count>0)
            {
                for (int g = 0; g < dt.Rows.Count; g++)
                {
                    genres = genres + dt.Rows[g]["Genre"].ToString() + ",";

                }
                genres = genres.Substring(0, genres.Length - 1);
            }
           
            return genres;
        }

        public string getProfilePublicPrivate(string userId)
        {
            string sql = "select  PublicViewYN from PersonalInfo where UserID=" + userId;
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt.Rows[0]["PublicViewYN"].ToString();

        }
        

        public DataTable getProfileCredits(string userId, string pageNo)
        {
            //getting profile news
            int recordsPerPage = 5;
            int startr = ((Convert.ToInt32(pageNo) - 1) * recordsPerPage) + 1;
            int lastr = ((Convert.ToInt32(pageNo)) * recordsPerPage);
            //string sql = "SELECT a.* FROM (SELECT ROW_NUMBER() OVER (ORDER BY  CreditId ASC) AS RowNum, * FROM Profile_CreditDetails  WHERE UserID='" + userId + "') a  WHERE UserID='" + userId + "' AND a.RowNum BETWEEN " + startr + " AND " + lastr;
            string sql = "SELECT * FROM Profile_CreditDetails  WHERE UserID='" + userId + "' ORDER BY  CreditId ASC ";
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }
        public DataTable getProfileAwards(string userId, string pageNo)
        {
            //getting profile news
            int recordsPerPage = 2;
            int startr = ((Convert.ToInt32(pageNo) - 1) * recordsPerPage) + 1;
            int lastr = ((Convert.ToInt32(pageNo)) * recordsPerPage);
            //string sql = "SELECT a.* FROM (SELECT ROW_NUMBER() OVER (ORDER BY  CreatDateTime desc) AS RowNum, * FROM Profile_Awards  WHERE UserID='" + userId + "') a  WHERE UserID='" + userId + "' AND a.RowNum BETWEEN " + startr + " AND " + lastr;
            string sql = "SELECT  * FROM Profile_Awards  WHERE UserID='" + userId + "' ORDER BY  CreatDateTime desc";
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }

        public DataTable getArtistTypes(string userId)
        {

            string sql = "SELECT * FROM profile_userArtistType left join ArtistType on ArtistType.ArtistTypeID=profile_userArtistType.ArtistTypeID where profile_userArtistType.UserID='" + userId + "' and ArtistType.Recstatus='AC' "; 
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }
        public DataTable getPersonalInfo(string userId)
        {

            string sql = "SELECT * FROM View_PersonalInfo left join mpm_Users on View_PersonalInfo.UserID=mpm_Users.id  where UserID='" + userId + "' "; 
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }
        public DataTable getProfileInfo(string userId)
        {

            string sql = "SELECT * FROM PersonalInfo left join mpm_Users on mpm_Users.id = PersonalInfo.UserID WHERE PersonalInfo.UserID='" + userId + "'";
            DataTable dt = DBUtils.ExecuteQuery(sql);
            return dt;

        }


    }
}