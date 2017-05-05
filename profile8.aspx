<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile8.aspx.cs" Inherits="SongCatelogApp.profile8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <!-- Bootstrap Core CSS -->
      <!-- <link href="https://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet"> -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900" rel="stylesheet">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/font-awesome.min.css">
    <link href="css/custom.css" rel="stylesheet" />
        <link href="css/wavesurfer.css" rel="stylesheet" />
            <script type='text/javascript' src='js/jquery.js?ver=1.12.4'></script><script>jQueryWP = jQuery;</script>
        <script type='text/javascript'>
            /* <![CDATA[ */
            var GmediaGallery = {};
            /* ]]> */
        </script>
    <style>
        .light-theme a{
        padding:15px;
        font-size: 21px;
        font-weight: bold;
        border: 1px solid #232323;
        margin-bottom: 20px;
        float: left;
        }
    </style>
           <script type='text/javascript' src='wavesurfer3/wavesurfer.min.js?ver=1.2.8'></script>
                        <script type='text/javascript' src='wavesurfer3/wavesurfer.js?ver=1.7'></script>

</head>
<body onload="loadNewsAwards()">
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <input type="hidden" name="hdnCounter" id="hdnCounter" value="1">
                <input type="hidden" name="hdnCounterFeatured" id="hdnCounterFeatured" value="1">
    <!-- Page Content -->
               <div class="row top-sec">
                <div class="col-md-12 user-cover">
                    <div class="cover-image" style="width: 100%;">
              
                        <asp:Image runat="server" ID="imgCover" />
                    </div>
                    <div class="user-image">
                         <asp:Image runat="server" id="imgProfile" Width="140" Height="140"></asp:Image>
                    </div>
                    <div class="user-info">
                        <h2><strong><asp:Label ID="lbluploader" runat="server"></asp:Label></strong></h2>
                        <p><asp:Label ID="lblemail" runat="server"></asp:Label></p>
                        <p><asp:Label ID="lblcountry" runat="server"></asp:Label></p>
                    </div>

                </div>
     
            </div>


            <div class="row main-sec">
                 <div class="col-sm-9 user-songs">

                        <div class="tab-content clearfix user-songs-tab">

                            <div>
    <%--<a  href="#1a" data-toggle="tab">All Songs</a>--%>
            <asp:HiddenField ID="hdnloadtype" runat="server" Value="all" />
                                         <h3>  <asp:LinkButton ID="lnkAllSongs" runat="server" onClick="linkAllSongs_Click" Text="All Songs" /></h3>
                   
                        <%--<a href="#2a" data-toggle="tab">Playlists</a>--%>
                        <h3><asp:LinkButton ID="lnkPlaylists" runat="server" onClick="linkPlaylists_Click" Text="Playlists" /></h3>
               
                    <%--<li onclick="FeaturedRunScript()"><a href="#3a" data-toggle="tab" >Featured</a>--%>
                    <h3><asp:LinkButton ID="lnkFeatured" runat="server" onClick="linkFeatured_Click" Text="Featured" /></h3>
                 
                                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
          <ContentTemplate>

                                 <div class="gmedia_gallery wavesurfer_module" id="GmediaGallery_80" data-gmid="80" data-module="wavesurfer">
                                       

                                        <div class="ws-soundList" id="soundList" runat="server">   
                      
                                                </div>
                                   
                                     <div >
                                                <script type="text/javascript" id="myscript">
                                                    (function ($) {
                                                        var settings = { "compact_list": "0", "color1": "a30283", "ID": 80, "nonce": "08187fd71d", "url": "", "moduleUrl": "" };
                                                        $('#GmediaGallery_80').gmWaveSurfer(settings);
                                                    })(jQuery);

                                                </script>
                                         </div>
                                    </div>
                                                     <span id="spanNext" runat="server"> 
                                                         <asp:LinkButton ID="LinkButton1" runat="server" onClick="loadNextSongsList" Text="Next" />
                                                          <a onclick="loadNextSongsList()" href="javascript:void(0)" style="font-size:16px;font-weight:bold;text-align:center;"><img src="images/next.png" width="150" height="50" /></a></span>
                                <span style="display:none;" id="loading"><img src="images/l3.gif"></span>   

              </ContentTemplate>
       </asp:UpdatePanel>
                            </div>

                     
                        </div>
                     
                     <div class="sub-tab">


                         <ul class="nav nav-pills sub-nav">
                             <li class="active">
                                 <a href="#i1a" data-toggle="tab">News</a>
                             </li>
                             <li><a href="#i2a" data-toggle="tab">Credits</a>
                             </li>
                             <li><a href="#i3a" data-toggle="tab">Awards</a>
                             </li>
                             <li>
                                 <a href="#i4a" data-toggle="tab">Reviews</a>
                             </li>


                         </ul>

                         <div class="tab-content clearfix sub-nav-tab">

                             <div class="tab-pane active" id="i1a">
                                 <input type="hidden" name="hdnNewsCounter" id="hdnNewsCounter" value="0" />
                                 <div class="news-list" id="newslist" runat="server">
                                 </div>

                                 <a onclick="loadMoreNews()" style="float: right; font-size: 16px; color: red;" href="javascript:void(0)" id="morenews" runat="server">More..</a>


                             </div>
                             <div class="tab-pane" id="i2a">
                                 <input type="hidden" name="hdnCreditsCounter" id="hdnCreditsCounter" value="0" />
                                 <table id="creditsList" runat="server" border="1" cellpadding="10">
                                 </table>

                                 <a onclick="loadMoreCredits()" style="float: right; font-size: 16px; color: red;" href="javascript:void(0)" id="morecredits" runat="server">More..</a>

                             </div>
                             <div class="tab-pane" id="i3a">
                                 <input type="hidden" name="hdnAwardsCounter" id="hdnAwardsCounter" value="0" />
                                 <div class="news-list" id="AwardsList" runat="server">
                                 </div>

                                 <a onclick="loadMoreAwards()" style="float: right; font-size: 16px; color: red;" href="javascript:void(0)" id="A1" runat="server">More..</a>

                             </div>
                             <div class="tab-pane" id="i4a">
                                 <input type="hidden" name="hdnReviewsCounter" id="hdnReviewsCounter" value="0" />
                                 <div class="news-list" id="reviewsList" runat="server">
                                 </div>

                                 <a onclick="loadMoreReviews()" style="float: right; font-size: 16px; color: red;" href="javascript:void(0)" id="moreReviews" runat="server">More..</a>

                             </div>

                         </div>
                     </div>


                     <div class="most-view-sec">
                         <h3>Most Viewed</h3>
                         <div class="row youtube-videos">
                             <div class="carousel slide multi-item-carousel" id="theCarousel">
                                 <div class="carousel-inner" id="videosPhotos" runat="server">
                  
                                    

                                     <!--  Example item end -->
                                 </div>
                                 <a class="left carousel-control" href="#theCarousel" data-slide="prev"><i class="glyphicon glyphicon-chevron-left"></i></a>
                                 <a class="right carousel-control" href="#theCarousel" data-slide="next"><i class="glyphicon glyphicon-chevron-right"></i></a>
                             </div>

                         </div>
                     </div>
       

                </div> 
      <div class="col-md-3 user-more-info">

                    <div class="user-basci-info">
                        <label>Joined</label>
                        <p id="">
                            <asp:Label runat="server" ID="lblJoined" Text=""></asp:Label></p>
                        <br>
                        <div class="social-links">
                            <asp:HyperLink ID="lnkWebsite" runat="server" Target="_blank"><i class="fa fa-globe" aria-hidden="true"></i></asp:HyperLink><br />
                            <asp:HyperLink ID="lnkFacebook" runat="server" Target="_blank"><i class="fa fa-facebook" aria-hidden="true"></i></asp:HyperLink><br />
                            <asp:HyperLink ID="lnkTwitter" runat="server" Target="_blank"><i class="fa fa-twitter" aria-hidden="true"></i></asp:HyperLink><br />

                        </div>
                        <br>
                        <label>PRO</label>
                        <p id="P4">
                            <asp:Label ID="lblPro" runat="server" Text=""></asp:Label></p>
                        <br>
                        <label>Organizations</label>
                        <p id="P5">
                            <asp:Label ID="lblOrg" Text="" runat="server"></asp:Label></p>

                        <br>
                        <label>BIO</label>
                        <p id="P8">
                            <asp:Label ID="lblBio" runat="server" Text=""></asp:Label>
                            <a id="bioMore" onclick="bioLoadMore()" runat="server">More..</a>

                        </p>
                    </div>
                </div>
               
            </div>
        </form>
    <!-- /.container -->
        <!-- jQuery Version 1.11.1 -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
    <script>

     

        function loadNextSongsList() {
            
            document.getElementById("loading").style.display = "block";
            document.getElementById("spanNext").style.display = "none";
            //setTimeout(function () { document.getElementById("loading").style.display = "none"; startworking() }, 6000);
             startworking();


        }

        function startworking() {

            var loadtype = document.getElementById("hdnloadtype").value;
            var url = "profile6.aspx/loadMoreSongs";
            if (loadtype == "all") {
                url = "profile6.aspx/loadMoreSongs";
            }
            if (loadtype == "featured") {
                url = "profile6.aspx/loadMoreSongsFeatured";
            }
           // console.log(12);
            var hdnReviewsCounter = document.getElementById("hdnCounter").value;
            var nextPage = parseInt(hdnReviewsCounter) + 1;
            $.ajax({
                type: "POST",
                data: JSON.stringify({ nextPage: nextPage }),
                url: "profile6.aspx/loadMoreSongs",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    document.getElementById("soundList").innerHTML = "";
                   // $("#soundList").append(data.d);
                    document.getElementById("soundList").innerHTML = data.d;
                   
                }

            });
            $(document).ajaxComplete(function () {
                testJ();
            });
            document.getElementById("hdnCounter").value = nextPage;


        }


        function testJ() {
            var output = 0;
            var fileref = document.createElement('link');
            fileref.rel = 'stylesheet';
            fileref.type = 'text/css';
            fileref.href = 'css/wavesurfer.css';
            document.getElementsByTagName('head')[0].appendChild(fileref);


            $.when(
      $.getScript("js/jquery.js?ver=1.12.4"),
      $.getScript("wavesurfer3/wavesurfer.min.js?ver=1.2.8"),
      $.getScript("wavesurfer3/wavesurfer.js?ver=1.7"),
      $.Deferred(function (deferred) {
          $(deferred.resolve);
      })
  ).done(function () {
      //if (jQuery.isReady) {
          (function ($) {

              var settings = { "compact_list": "0", "color1": "a30283", "ID": 80, "nonce": "08187fd71d", "url": "", "moduleUrl": "" };

              $(document).ajaxComplete(function () {
                  $('#GmediaGallery_80').gmWaveSurfer(settings);
                  document.getElementById("loading").style.display = "none";
                  document.getElementById("spanNext").style.display = "block";

                //  output = 1;
              });
              
              
          })(jQuery);
          
      //}
      //else {
      //    setTimeout((function ($) {
      //        alert(12);

      //        var settings = { "compact_list": "0", "color1": "a30283", "ID": 80, "nonce": "08187fd71d", "url": "", "moduleUrl": "" };
      //        $('#GmediaGallery_80').gmWaveSurfer(settings);
      //    })(jQuery), 50000) //wait ten seconds before continuing
      //}
      
       
  });

            //console.log("output - "+output);
            //return output;
        }

    </script>
        <script>// Instantiate the Bootstrap carousel
            $('.multi-item-carousel').carousel({
                interval: 2000
            });

            // for every slide in carousel, copy the next slide's item in the slide.
            // Do the same for the next, next item.
            $('.multi-item-carousel .item').each(function () {
                var next = $(this).next();
                if (!next.length) {
                    next = $(this).siblings(':first');
                }
                next.children(':first-child').clone().appendTo($(this));

                if (next.next().length > 0) {
                    next.next().children(':first-child').clone().appendTo($(this));
                } else {
                    $(this).siblings(':first').children(':first-child').clone().appendTo($(this));
                }
            });
            //# sourceURL=pen.js
</script>
    <script type="text/javascript">
        function bioLoadMore() {
            $.ajax({
                type: "POST",
                url: "profile6.aspx/bioLoadMore",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#lblBio").html(data.d);
                    $("#bioMore").attr("style", "display:none");

                }

            });
        }

        function loadNewsAwards() {
            loadMoreNews();
            loadMoreAwards();
            loadMoreCredits();
            loadMoreReviews();
            //loadVideosPhotos();
        }

        function loadVideosPhotos() {

            $.ajax({
                type: "POST",
                url: "profile6.aspx/loadVideosPhotos",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#videosPhotos").append(data.d);
                }

            });

        }

        function loadMoreReviews() {
            var hdnReviewsCounter = document.getElementById("hdnReviewsCounter").value;
            var nextPage = parseInt(hdnReviewsCounter) + 1;

            $.ajax({
                type: "POST",
                url: "profile6.aspx/loadMoreReviews",
                data: JSON.stringify({ nextPage: nextPage }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#reviewsList").append(data.d);
                }

            });

            document.getElementById("hdnReviewsCounter").value = nextPage;
        }
        function loadMoreCredits() {
            var hdnCreditsCounter = document.getElementById("hdnCreditsCounter").value;
            var nextPage = parseInt(hdnCreditsCounter) + 1;

            $.ajax({
                type: "POST",
                url: "profile6.aspx/loadMoreCredits",
                data: JSON.stringify({ nextPage: nextPage }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#creditsList").append(data.d);
                }

            });

            document.getElementById("hdnCreditsCounter").value = nextPage;
        }


        function loadMoreNews() {
            var hdnNewsCounter = document.getElementById("hdnNewsCounter").value;
            var nextPage = parseInt(hdnNewsCounter) + 1;

            $.ajax({
                type: "POST",
                url: "profile6.aspx/loadMoreNews",
                data: JSON.stringify({ nextPage: nextPage }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#newslist").append(data.d);
                }

            });

            document.getElementById("hdnNewsCounter").value = nextPage;
        }
        function loadMoreAwards() {
            var hdnNewsCounter = document.getElementById("hdnAwardsCounter").value;
            var nextPage = parseInt(hdnNewsCounter) + 1;

            $.ajax({
                type: "POST",
                url: "profile6.aspx/loadMoreAwards",
                data: JSON.stringify({ nextPage: nextPage }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#AwardsList").append(data.d);
                }

            });

            document.getElementById("hdnAwardsCounter").value = nextPage;
        }
    </script>
</body>
</html>
