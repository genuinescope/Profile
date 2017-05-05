<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile7.aspx.cs" Inherits="SongCatelogApp.profile7" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <!-- Bootstrap Core CSS -->
      <!-- <link href="https://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet"> -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900" rel="stylesheet" />
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
        <input type="hidden" name="hdnCounter" id="hdnCounter" value="1">
    <!-- Page Content -->
    <div class="container ">

            <div class="row top-sec">
                <div class="col-md-12 user-cover">
                    <div class="cover-image">
                        <img src="../images/user/cover.jpg">
                    </div>
                    <div class="user-image">
                         <asp:Image runat="server" id="imgProfile"></asp:Image>
                    </div>
                    <div class="user-info">
                        <h2><strong><asp:Label ID="lbluploader" runat="server"></asp:Label></strong></h2>
                        <p><asp:Label ID="lblemail" runat="server"></asp:Label></p>
                        <p><asp:Label ID="lblcountry" runat="server"></asp:Label></p>
                    </div>

                </div>
                <ul  class="nav nav-pills user-nav-top">
                    <li class="active">
                        <a  href="#1a" data-toggle="tab">All Songs</a>
                    </li>
                    <li><a href="#2a" data-toggle="tab">Playlists</a>
                    </li>
                    <li onclick="FeaturedRunScript()"><a href="#3a" data-toggle="tab">Featured</a>
                    </li>
                </ul>
            </div>


            <div class="row main-sec">
                 <div class="col-sm-9 user-songs">

                        <div class="tab-content clearfix user-songs-tab">

                            <div class="tab-pane active" id="1a">

                                 
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
                                                     <span id="spanNext">  <a onclick="loadNextSongsList()" href="javascript:void(0)" style="font-size:16px;font-weight:bold;text-align:center;"><img src="images/next.png" /></a></span>
                                <span style="display:none;" id="loading"><img src="images/l3.gif"></span>   
                            </div>

                            <div class="tab-pane" id="2a">
                                You don't have any play list.
                            </div>

                            <div class="tab-pane" id="3a">
                                                                   
                                 <div class="gmedia_gallery wavesurfer_module" id="GmediaGallery_81" data-gmid="81" data-module="wavesurfer">
                                       

                                        <div class="ws-soundList" id="soundListFeatured" runat="server">   
                      
                                                </div>
                                   
                                     <div >
                                                <script type="text/javascript" id="myscriptFeatured">
                                                    (function ($) {
                                                        var settings = { "compact_list": "0", "color1": "a30283", "ID": 81, "nonce": "08187fd71d", "url": "", "moduleUrl": "" };
                                                        $('#GmediaGallery_81').gmWaveSurfer(settings);
                                                    })(jQuery);

                                                </script>
                                         </div>
                                    </div>
                                                     <span id="spanNextFeatured">  <a onclick="loadNextSongsListFeatured()" href="javascript:void(0)" style="font-size:16px;font-weight:bold;text-align:center;"><img src="images/next.png" /></a></span>
                                <span style="display:none;" id="loadingFeatured"><img src="images/l3.gif"></span>   
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

    </div>
        </form>
    <!-- /.container -->
        <!-- jQuery Version 1.11.1 -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
    <script>

        function FeaturedRunScript() {
            console.log(12);
        
                document.getElementById("loadingFeatured").style.display = "none";

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

                            var settings = { "compact_list": "0", "color1": "a30283", "ID": 81, "nonce": "08187fd71d", "url": "", "moduleUrl": "" };
                            $('#GmediaGallery_81').gmWaveSurfer(settings);
                        })(jQuery);
                        document.getElementById("spanNextFeatured").style.display = "block";


                });


        }
        function loadNextSongsListFeatured() {
            document.getElementById("loadingFeatured").style.display = "block";
            document.getElementById("spanNextFeatured").style.display = "none";
            setTimeout(function () { document.getElementById("loadingFeatured").style.display = "none"; startworkingFeatured() }, 10000);


        }

        function testJFeatured() {

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

          var settings = { "compact_list": "0", "color1": "a30283", "ID": 81, "nonce": "08187fd71d", "url": "", "moduleUrl": "" };
          $('#GmediaGallery_81').gmWaveSurfer(settings);
      })(jQuery);
      document.getElementById("spanNextFeatured").style.display = "block";


  });
        }
        function startworkingFeatured() {
            // console.log(12);
            var hdnCounterFeatured = document.getElementById("hdnCounterFeatured").value;
            var nextPage = parseInt(hdnCounterFeatured) + 1;
            $.ajax({
                type: "POST",
                data: JSON.stringify({ nextPage: nextPage }),
                url: "profile6.aspx/loadMoreSongsFeatured",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    document.getElementById("soundListFeatured").innerHTML = "";
                    //$("#soundListFeatured").append(data.d);
                     document.getElementById("soundListFeatured").innerHTML = data.d;
                    testJFeatured();

                }

            });
            document.getElementById("hdnCounterFeatured").value = nextPage;


        }


        function loadNextSongsList() {
            document.getElementById("loading").style.display = "block";
            document.getElementById("spanNext").style.display = "none";
            
            setTimeout(function () { document.getElementById("loading").style.display = "none"; startworking() }, 3000);


        }

        function startworking() {
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
                    $("#soundList").append(data.d);
                    // document.getElementById("soundList").innerHTML = data.d;
                    testJ();

                }

            });
            document.getElementById("hdnCounter").value = nextPage;


        }
        function testJ() {

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
          $('#GmediaGallery_80').gmWaveSurfer(settings);
      })(jQuery);
      document.getElementById("spanNext").style.display = "block";
      //}
      //else {
      //    setTimeout((function ($) {
      //        alert(12);

      //        var settings = { "compact_list": "0", "color1": "a30283", "ID": 80, "nonce": "08187fd71d", "url": "", "moduleUrl": "" };
      //        $('#GmediaGallery_80').gmWaveSurfer(settings);
      //    })(jQuery), 50000) //wait ten seconds before continuing
      //}


  });
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
                url: "profile5.aspx/bioLoadMore",
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
                url: "profile5.aspx/loadVideosPhotos",
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
                url: "profile5.aspx/loadMoreReviews",
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
                url: "profile5.aspx/loadMoreCredits",
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
                url: "profile5.aspx/loadMoreNews",
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
                url: "profile5.aspx/loadMoreAwards",
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
