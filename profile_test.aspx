﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile_test.aspx.cs" Inherits="SongCatelogApp.profile_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <!-- Bootstrap Core CSS -->
       <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900" rel="stylesheet">
   <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css'>

    <link rel="stylesheet" href="/css/font-awesome.min.css">
    <link href="/css/custom.css?v=15_4_2017" rel="stylesheet" />
        <link href="/css/wavesurfer.css" rel="stylesheet" />
       
       <script src='//cdnjs.cloudflare.com/ajax/libs/jquery/2.2.2/jquery.min.js'></script>
    <script src='//maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js'></script>
         <script src="http://code.jquery.com/jquery-latest.min.js"></script> 
        <script>jQueryWP = jQuery;</script>
        <script type='text/javascript'>
         
            /* <![CDATA[ */
            var GmediaGallery = {};
            /* ]]> */

         
        </script>


  
</head>
<body>
    <form id="Form1" runat="server">
        <!-- Page Content -->
        <div class="container ">

            <div class="row top-sec">
                
                <%--<a data-toggle="modal"  data-target="#myModal">Click me !</a>--%>
                <div class="col-md-12 user-cover">
                   <div class="cover-image" style="width: 100%;">
                        <div runat="server" id="EmptyCover"></div>
                        <asp:Image runat="server" ID="imgCover" />
                    </div>
                    <div class="user-image">
                        <asp:Image runat="server" ID="imgProfile" Width="180" Height="180"></asp:Image>
                    </div>
                    <div class="user-info">
                        
                        <%--<a data-toggle="modal" href="../ContactForm.aspx" data-target="#myModal">
                            <img src="/images/mail.png" width="70" height="40" />
                        </a>--%>
                        <div class="user-profile-info">
                            <div id="divProfile_ArtistName">
                                <asp:Label ID="lbluploader" runat="server"></asp:Label></div>
                             
                           
                            
                        
                            <div id="divProfile_ArtistType">
                                <asp:Label ID="lblArtistTypes" runat="server"></asp:Label></div>
                            <div id="divProfile_state">
                                <asp:Label ID="lblcity" runat="server"></asp:Label></div>
                            <div id="divProfile_County"><asp:Label ID="lblCountry" runat="server"></asp:Label></div>


                            <asp:Image runat="server" ID="id_flag" Width="40" />

                            <br />
                            <button class="bio-more-btn">More Info</button>
                        </div>



                    </div>

                </div>





                <div class="row">
                    <div class="col-md-9">

                    </div>
                    <div class="col-md-3">

                    </div>
                </div>

                <ul class="nav nav-pills user-nav-top">
           
                   
                  
                    <li class="user-contact-msg">
                       <a data-toggle="modal"  data-target="#myModal" > <i class="fa fa-envelope" aria-hidden="true"></i></a>
                    </li>
                </ul>


            



                <%-- <h3>  <asp:LinkButton ID="lnkAllSongs" runat="server"  CommandArgument='121' OnCommand="Button1_Click"   /></h3>
                   
                        <%--<a href="#2a" data-toggle="tab">Playlists</a>--%>
                

                <%--<li onclick="FeaturedRunScript()"><a href="#3a" data-toggle="tab" >Featured</a>--%>
                <%--<h3><asp:LinkButton ID="lnkFeatured" runat="server" onClick="Button1_Click" Text="Featured" CustomParameter="Value2"  /></h3>--%>
            </div>

            <input type="hidden" name="counter" id="counter" value="5" />
            <input type="hidden" name="loadtimes" id="loadtimes" value="0" />
            <input type="hidden" name="clicked" id="clicked" value="0" />

            <div class="row main-sec">
                <div class="col-sm-9 user-songs">

                    <div class="tab-content clearfix user-songs-tab">

                        <div id="songs" runat="server" style="overflow: scroll;max-height:600px;">
                                <div id="playlistDetails" runat="server"></div>

                            <div class="gmedia_gallery wavesurfer_module" id="GmediaGallery_80" data-gmid="80" data-module="wavesurfer">

                                  <div class="ws-soundList" id="songsList" runat="server">
                                   
                                        
                                            

                                  </div>
                                <div class="ws-soundCompactList"></div>

                               
                            </div>
                        </div>
                      <script type="text/javascript">
                          jQuery(function ($) {
                              var settings = { "show_big_cover": "1", "show_download_button": "1", "link_button_text": "Link Button", "color1": "e63a3a", "color2": "545454", "color3": "993737", "color4": "f2e9e9", "ID": 80, "nonce": "513961313f", "url": "https:\/\/codeasily.com\/portfolio\/gmedia-gallery-modules\/wavesurfer", "moduleUrl": "https:\/\/codeasily.com\/wp-content\/grand-media\/module\/wavesurfer" };
                              $('#GmediaGallery_80').gmWaveSurfer(settings);
                          });</script>

                 

                         <a id="loading" style="text-align:center" onclick="loadSongs()"><h2><img src="/images/loadmore.png" class="img-responsive" width="180" height="80" style="text-align:center;"></h2></a>



                    </div>
                          <div class="sub-tab" id="newstabs" runat="server">


                        <ul class="nav nav-pills sub-nav">
                                            <li id="lnkNews" runat="server">

                                <a href="#i1a" data-toggle="tab">News</a>
                            </li>

                            <li id="lnkCredits" runat="server"><a href="#i2a" data-toggle="tab">Credits</a>

                            </li>

                            <li id="lnkAwards" runat="server"><a href="#i3a" data-toggle="tab">Awards</a>

                            </li>

                            <li id="lnkReviews" runat="server">

                                <a href="#i4a" data-toggle="tab">Reviews</a>
                            </li>

                        </ul>

                        <div class="tab-content clearfix sub-nav-tab">

                        <div class="tab-pane" id="i1a" runat="server">

                                <input type="hidden" name="hdnNewsCounter" id="hdnNewsCounter" value="1" />
                                <div class="news-list" id="newslist" runat="server">
                                </div>

                                <div class="more-btn-contain">
                                    <a onclick="loadMoreNews()" class="more-btn-lg" href="javascript:void(0)" id="morenews" runat="server">More</a>
                                </div>
                        
                            </div>
                            <div class="tab-pane" id="i2a" runat="server">
                                <input type="hidden" name="hdnCreditsCounter" id="hdnCreditsCounter" value="1" />
                               <div id="divCredits" runat="server">
                                   
                               </div>
                                <br />
                                <div class="more-btn-contain">
                                    <a onclick="loadMoreCredits()"  class="more-btn-lg" href="javascript:void(0)" id="morecredits" runat="server">More..</a>
                                </div>
                            </div>
                            <div class="tab-pane" id="i3a" runat="server">
                                <input type="hidden" name="hdnAwardsCounter" id="hdnAwardsCounter" value="1" />
                                <div class="news-list" id="AwardsList" runat="server">
                                </div>
                                <div class="more-btn-contain">
                                    <a onclick="loadMoreAwards()" class="more-btn-lg"   href="javascript:void(0)" id="MoreAwards" runat="server">More..</a>
                                </div>
                            </div>
                            <div class="tab-pane" id="i4a" runat="server">
                                <input type="hidden" name="hdnReviewsCounter" id="hdnReviewsCounter" value="1" />
                                <div class="news-list" id="reviewsList" runat="server">
                                </div>
                                <div class="more-btn-contain">
                                    <a onclick="loadMoreReviews()"  class="more-btn-lg" href="javascript:void(0)" id="moreReviews" runat="server">More..</a>
                                </div>
                            </div>

                        </div>
                    </div>


                    <div class="videotitle"><asp:Label runat="server" ID="lblVideoTitle"></asp:Label></div>


                    <div class="most-view-sec" id="videosdiv" runat="server">
                        <%--<h3>Most Viewed</h3>--%>
                        <div class="youtube-videos">

                            <div class="carousel slide multi-item-carousel-videos" id="theCarouselVideos"  data-interval="false">

                                <div id="divVideos" class="carousel-inner" runat="server">
                                    <!--  Example item end -->


                                </div>
                                <a class="left carousel-control" href="#theCarouselVideos" data-slide="prev"><i class="glyphicon glyphicon-chevron-left"></i></a>
                                <a class="right carousel-control" href="#theCarouselVideos" data-slide="next"><i class="glyphicon glyphicon-chevron-right"></i></a>
                            </div>



                        </div>
                       
                    </div>


                    <div class="phototitle"><asp:Label runat="server" ID="lblPhotoTitle"></asp:Label></div>


                      <div class="most-view-sec" id="photosdiv" runat="server">
                          <div class="youtube-videos">
                              <div class="carousel slide multi-item-carousel" id="theCarouselPhotos">
                                  <div id="divPhotos" class="carousel-inner" runat="server">
                                      <!--  Example item end -->


                                  </div>
                                  <a class="left carousel-control" href="#theCarouselPhotos" data-slide="prev"><i class="glyphicon glyphicon-chevron-left"></i></a>
                                  <a class="right carousel-control" href="#theCarouselPhotos" data-slide="next"><i class="glyphicon glyphicon-chevron-right"></i></a>
                              </div>
                          </div>
                          </div>
                </div>



                <div class="col-md-3 user-more-info">

                    <div class="user-basci-info">
                        <div class="bio-mobile">
                            <button class="mobile-bio-close"> <i class="fa fa-window-close" aria-hidden="true"></i></button>
                        </div>
                                                <%--<label runat="server" id="sociallinks">Social Links</label>--%>
                        <div class="social-links">



                            

                            <ul class="list-inline">

                                <li>
                                    <p runat="server" id="pweb">
                                        
                                        <asp:HyperLink ID="lnkWebsite" runat="server" Target="_blank">
                                            <i class="fa fa-globe" aria-hidden="true"></i>
                                        </asp:HyperLink>
                                    </p>
                                </li>

                                <li>
                                    <p runat="server" id="pfb">
                                        
                                        <asp:HyperLink ID="lnkFacebook" runat="server" Target="_blank">
                                            <i class="fa fa-facebook" aria-hidden="true"></i>
                                        </asp:HyperLink>
                                    </p>
                                </li>
                                <li>
                                    <p runat="server" id="pins">
                                        
                                        <asp:HyperLink ID="lnkInstagram" runat="server" Target="_blank">
                                            <i class="fa fa-instagram" aria-hidden="true"></i>
                                        </asp:HyperLink>
                                    </p>
                                </li>

                                <li>
                                    <p runat="server" id="pt">
                                        
                                        <asp:HyperLink ID="lnkTwitter" runat="server" Target="_blank">
                                            <i class="fa fa-twitter" aria-hidden="true"></i>
                                        </asp:HyperLink>
                                    </p>
                                </li>
                                <li>
                                    <p runat="server" id="plink">
                                        
                                        <asp:HyperLink ID="lnkLinked" runat="server" Target="_blank">
                                            <i class="fa fa-linkedin" aria-hidden="true"></i>
                                        </asp:HyperLink>
                                    </p>
                                </li>
                                <li>
                                    <p runat="server" id="psc">
                                        
                                        <asp:HyperLink ID="lblSC" runat="server" Target="_blank">
                                            <i class="fa fa-soundcloud" aria-hidden="true"></i>
                                        </asp:HyperLink>
                                    </p>
                                </li>
                                <li>
                                    <p runat="server" id="pyout">
                                        
                                        <asp:HyperLink ID="lblyoutube" runat="server" Target="_blank">
                                            <i class="fa fa-youtube-play" aria-hidden="true"></i>
                                        </asp:HyperLink>
                                    </p>
                                </li>
                            </ul>

                            
                            
                            
                            


                        </div>
                     <%--   <label>Joined</label>
                        <div id="">
                            <asp:Label runat="server" ID="lblJoined" Text=""></asp:Label>
                        </div>
                        <br>--%>
                        <label runat="server" id="bio">BIO</label>
                        <div id="P8">
                            <asp:Label ID="lblBio" runat="server" Text=""></asp:Label>
                            <a id="bioMore" onclick="bioLoadMore()" runat="server">More..</a>
                            <a id="bioLess" onclick="bioLoadLess()" runat="server" style="display:none;">Less..</a>
                        </div>
                        <br>
                        <div>

                        <div id="userGenre" runat="server" class="genreList-user" >

                        </div>
                        </div>



                        <br>

                        <div class="row">
                            <div class="col-md-6">
                                         <label runat="server" id="pro">PRO</label>
                        <p id="P4">
                            <asp:Label ID="lblPro" runat="server" Text=""></asp:Label>
                        </p>
                            </div>
                            <div class="col-md-6">
                                    <label runat="server" id="caeIP">CAE/IPI #</label>
                        <p id="P1">
                            <asp:Label ID="lblCaeIP" runat="server" Text=""></asp:Label>
                        </p>
                            </div>
                        </div>
                       
                       
                        <br>
                        <label runat="server" id="org">Affiliations</label>
                        <p id="P5">
                            <asp:Label ID="lblOrg" Text="" runat="server"></asp:Label>
                        </p>

                        <br>
                    </div>
                </div>



            </div>

        </div>
     <div id="myModalmetadata" class="modal">
                        <div class="modal-content modal-meta"  >
                            <div class="modal-header">
                                <button type="button" onclick="HideSongManagePanel()" class="back-prof-close btn-dark" data-dismiss="modal"> <i class="fa fa-times" aria-hidden="true"></i></button>
                                <ul class='nav nav-pills pop-nav'>
                                            <li class='active'><a data-toggle='tab' href='#vis_Basic'   >Basic Info</a>
                                            </li>
                                            <li><a data-toggle='tab' href='#vis_MetaData'>Admin Info</a>
                                            </li>
                                           <li><a data-toggle='tab' href='#vis_MetaDataLyrics'>Lyrics Info</a>
                                            </li>
                                        </ul>
                            </div>
                            <div class="modal-body">
                                <div id="DivSongID_Medatadata" style="display: none"></div>
                                <div class="tab-content">
                                    <div id='vis_Basic' class='tab-pane fade  in active'>
                                        
                                       
                                    </div>

                                    <div id='vis_MetaData' class='tab-pane fade'>
                                      
                      
                                   
                                         </div>
                                    <div id='vis_MetaDataLyrics' class='tab-pane fade'>
                                      
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                 <h4 class="modal-title">Contact</h4>

            </div>
            <div class="modal-body" id="modalbody">


      <input type="hidden" name="hdncaptcha" id="hdncaptcha" value="">
        <input type="hidden" name="hdnusername" id="hdnusername" value="">
        
        <div class="controls msg-box">

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="form_name">Name *</label>
                        <input type="text" name="fromname" id="fromname" class="form-control" placeholder="Please Enter Your Name *" required="required" data-error="Firstname is required.">
                        <div class="help-block with-errors"></div>
                    </div>
                </div>
                                <div class="col-md-12">
                    <div class="form-group">
                        <label for="form_email">Email *</label>
                        <input  type="email" name="email" id="email" class="form-control" placeholder="Please Enter Your Email *" required="required" data-error="Valid email is required.">
                        <div class="help-block with-errors"></div>
                    </div>
                </div>
                
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="form_lastname">Subject *</label>
                        <input  type="text" name="subject" id="subject" class="form-control" placeholder="Please Enter Subject *" required="required" data-error="Subject is required.">
                        <div class="help-block with-errors"></div>
                    </div>
                </div>
                
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="form_message">Message *</label>
                        <textarea  name="message" class="form-control" id="message" placeholder="Message for me *" rows="4" required="required" data-error="Please,leave us a message."></textarea>
                        <div class="help-block with-errors"></div>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="form-group captcha-box">

                        <div class="row">
                            <label class="col-sm-3 control-label text-right" id="Label1">Captcha </label>
                            <label class="col-sm-3 control-label text-right" id="captchaOperation"></label>
                            <div class="col-sm-6">
                                <input type="text" class="form-control" name="captcha" id="captcha" data-match="#hdncaptcha" required="required" data-match-error="Captcha Does not Match"/>
                                <div id="error" style="color:red;display:none;">Invalid Captcha</div>
                            </div>
                        </div>

                    </div>
                   
                </div>
               
                
            </div>
           <br />
            <div class="row">
                <div class="col-md-12">
                    <input type="button" width="100%" class="btn btn-success btn-send" value="Send message" onclick="return sendMail();" />
                </div>
            </div>


        </div>

        <div class="controls">

          
        </div>




            </div>
           
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<!-- /.modal -->

    </form>

    <!-- /.container -->
        <!-- jQuery Version 1.11.1 -->
          
    <!-- Bootstrap Core JavaScript -->
  
                        

      <script type='text/javascript' src='/wavesurfer5/wavesurfer.min.js?ver=1.2.8'></script>
                        <script type='text/javascript' src='/wavesurfer5/wavesurfer.js?ver=1.7'></script>
 
    <script>
        function getQueryVariableUserId() {
            var pathArray = window.location.pathname.split('/');
            var firstlocation_userId = 0;

            if (pathArray[2] == "beta") {
                firstlocation_userId = pathArray[3];
            }
            else {
                firstlocation_userId = pathArray[2];
            }
            return firstlocation_userId;

        }

        function getQueryVariable(variable) {
            var query = window.location.search.substring(1);
            var vars = query.split("&");
            for (var i = 0; i < vars.length; i++) {
                var pair = vars[i].split("=");
                if (pair[0] == variable) { return pair[1]; }
            }
            return (false);
        }
        function loadSongs() {


            var userid = getQueryVariableUserId();
            var counter = document.getElementById("counter").value;
            var newcounter = parseInt(counter) + 5;
            document.getElementById("loading").innerHTML = "<h2><img src='/images/loadingbar.gif' class='img-responsive' width='180' height='80' style='text-align:center;'></h2>";

            $.ajax({
                type: "POST",
                //url: "loadMoreNews",
                data: JSON.stringify({ userid: userid, songstart: counter }),
                url: "/profileMethods.asmx/loadSongs",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    // document.getElementById("songsList").innerHTML = data.d;
                    document.getElementById("counter").value = newcounter;
                    $("#songsList").append(data.d);

                    var settings = { "show_big_cover": "1", "show_download_button": "1", "link_button_text": "Link Button", "color1": "e63a3a", "color2": "545454", "color3": "993737", "color4": "f2e9e9", "ID": 80, "nonce": "513961313f", "url": "https:\/\/codeasily.com\/portfolio\/gmedia-gallery-modules\/wavesurfer", "moduleUrl": "https:\/\/codeasily.com\/wp-content\/grand-media\/module\/wavesurfer" };
                    $('#GmediaGallery_80').gmWaveSurfer(settings);
                    checkmoreAvailable(userid, newcounter);
                    
                },
                error: function (textStatus, errorThrown) {

                }
            });


            


        }

        function checkmoreAvailable(userid,lastloadedSongsCount) {
            $.ajax({
                type: "POST",
                //url: "loadMoreNews",
                data: JSON.stringify({ userid: userid, lastloadedSongsCount: lastloadedSongsCount }),
                url: "/profileMethods.asmx/checkMoreSongsAvailable",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                   // console.log(data.d);
                    if (data.d) {
                        document.getElementById("loading").innerHTML = "<h2><img src='/images/loadmore.png' class='img-responsive' width='180' height='80' style='text-align:center;'></h2>";
                        document.getElementById("loading").style.display = "block";
                    }
                    else {
                        document.getElementById("loading").style.display = "none";
                    }
                },
                error: function (textStatus, errorThrown) {

                }
            });
        }


        // Instantiate the Bootstrap carousel
      //  loadSongs();
        $('#theCarouselVideos').carousel({
            //interval: 4000
        })

        $('.multi-item-carousel-videos .item').each(function () {
            var next = $(this).next();
            if (!next.length) {
                next = $(this).siblings(':first');
            }
            next.children(':first-child').clone().appendTo($(this));

            for (var i = 0; i < 2; i++) {
                next = next.next();
                if (!next.length) {
                    next = $(this).siblings(':first');
                }

                next.children(':first-child').clone().appendTo($(this));
            }
        });

        $('#theCarouselPhotos').carousel({
            interval: 4000
        })

        $('.multi-item-carousel .item').each(function () {
            var next = $(this).next();
            if (!next.length) {
                next = $(this).siblings(':first');
            }
            next.children(':first-child').clone().appendTo($(this));

            for (var i = 0; i < 2; i++) {
                next = next.next();
                if (!next.length) {
                    next = $(this).siblings(':first');
                }

                next.children(':first-child').clone().appendTo($(this));
            }
        });
        //# sourceURL=pen.js
    </script>
    <script type="text/javascript">
        function songDetails(songid) {

            var modal = document.getElementById('myModalmetadata');
            modal.style.display = "block";
            PopulateBasicData(songid);
            PopulateMetaData(songid);
            PopulateLyrics(songid);

            return false;
        }
        function HideSongManagePanel() {
            var modal = document.getElementById('myModalmetadata');
            modal.style.display = "none";

        }


        function PopulateLyrics(songid) {

            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ SongID: songid }),
                url: "/profileMethods.asmx/GetSongLyrics",
                success: function (result) {

                    document.getElementById("vis_MetaDataLyrics").innerHTML = result.d;
                },
                error: function (xhr, textStatus, error) {

                },
                statusCode:
                {
                    500: function () {
                        GlobleSuccess = true;
                        //alert("Your session has expired. Please log in again."); location.reload();
                        //alert('got error 500');
                    },
                    350: function () {
                        GlobleSuccess = true;
                        // alert("Your session has expired. Please log in again.");
                        location.reload();
                    }
                }
            });
        }
        function PopulateMetaData(songid) {

            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ SongID: songid }),
                url: "/profileMethods.asmx/GetSongMetadataDetails",
                success: function (result) {

                    document.getElementById("vis_MetaData").innerHTML = result.d;
                },
                error: function (xhr, textStatus, error) {

                },
                statusCode:
                {
                    500: function () {
                        GlobleSuccess = true;
                        //alert("Your session has expired. Please log in again."); location.reload();
                        //alert('got error 500');
                    },
                    350: function () {
                        GlobleSuccess = true;
                        // alert("Your session has expired. Please log in again.");
                        location.reload();
                    }
                }
            });
        }
        function PopulateBasicData(songid) {

            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ SongID: songid }),
                url: "/profileMethods.asmx/GetSongDetails",
                success: function (result) {

                    document.getElementById("vis_Basic").innerHTML = result.d;
                },
                error: function (xhr, textStatus, error) {

                },
                statusCode:
                {
                    500: function () {
                        GlobleSuccess = true;
                        //alert("Your session has expired. Please log in again."); location.reload();
                        //alert('got error 500');
                    },
                    350: function () {
                        GlobleSuccess = true;
                        // alert("Your session has expired. Please log in again.");
                        location.reload();
                    }
                }
            });
        }
        function nl2br(str, is_xhtml) {
            var breakTag = (is_xhtml || typeof is_xhtml === 'undefined') ? '<br />' : '<br>';
            return (str + '').replace(/([^>\r\n]?)(\r\n|\n\r|\r|\n)/g, '$1' + breakTag + '$2');
        }
        function bioLoadLess() {
            var userid = getQueryVariableUserId();
            //str.substr(1, 4)
            var strBio = $("#lblBio").html();
            var displayBio = strBio.substr(0, 300);
            $("#lblBio").html(displayBio);
            $("#bioMore").attr("style", "display:block");
            $("#bioLess").attr("style", "display:none");


        }

        function bioLoadMore() {
            var userid = getQueryVariableUserId();
            $.ajax({
                type: "POST",
                data: JSON.stringify({ userId: userid }),
                url: "/profileMethods.asmx/bioLoadMore",
                //url: "profile5.aspx/bioLoadMore",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var bioDisplay = nl2br(data.d, false);
                    $("#lblBio").html(bioDisplay);
                    $("#bioMore").attr("style", "display:none");
                    $("#bioLess").attr("style", "display:block");

                }

            });
        }


     
        function loadNewsAwards() {

            //    //get user id


            //    loadMoreNews();
            //    loadMoreAwards();
            //    loadMoreCredits();
            //    loadMoreReviews();



            //  loadVideosPhotos();
        }

        function loadVideosPhotos() {
            var userid = getQueryVariableUserId();
            $.ajax({
                type: "POST",
                url: "/profileMethods.asmx/loadVideosPhotos",
                data: JSON.stringify({ userId: userid }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == "") {
                        $("#videosdiv").attr("style", "display:none");
                    }
                    $("#videosPhotos").append(data.d);
                }

            });

        }

        function loadMoreReviews() {
            var userid = getQueryVariableUserId();
            var hdnReviewsCounter = document.getElementById("hdnReviewsCounter").value;
            var nextPage = parseInt(hdnReviewsCounter) + 1;

            $.ajax({
                type: "POST",
                //url: "profile5.aspx/loadMoreReviews",
                url: "/profileMethods.asmx/loadMoreReviews",
                data: JSON.stringify({ nextPage: nextPage, userId: userid }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != "") {
                        $("#reviewsList").append(data.d);
                        //document.getElementById("moreReviews").style.display = "block";
                    }

                }

            });

            $.ajax({
                type: "POST",
                //url: "loadMoreNews",
                data: JSON.stringify({ nextPage: nextPage, userId: userid }),
                url: "/profileMethods.asmx/checkmoreAvailableReviews",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == 0) {
                        document.getElementById("moreReviews").style.display = "none";
                    }
                    //else {
                    //    document.getElementById("moreReviews").style.display = "block";
                    //}
                }
            });
            document.getElementById("hdnReviewsCounter").value = nextPage;
        }
        function loadMoreCredits() {
            var userid = getQueryVariableUserId();
            var hdnCreditsCounter = document.getElementById("hdnCreditsCounter").value;
            var nextPage = parseInt(hdnCreditsCounter) + 1;

            $.ajax({
                type: "POST",
                //url: "profile5.aspx/loadMoreCredits",
                url: "/profileMethods.asmx/loadMoreCredits",
                data: JSON.stringify({ nextPage: nextPage, userId: userid }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data.d);
                    if (data.d != "") {
                        $("#creditsList").append(data.d);
                        // document.getElementById("morecredits").style.display = "block";

                    }

                },
                error: function (textStatus, errorThrown) {
                    console.log(textStatus);
                    console.log(textStatus);
                }

            });
            $.ajax({
                type: "POST",
                //url: "loadMoreNews",
                data: JSON.stringify({ nextPage: nextPage, userId: userid }),
                url: "/profileMethods.asmx/checkmoreAvailableCredits",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == 0) {
                        document.getElementById("morecredits").style.display = "none";
                    }
                    //else {
                    //    document.getElementById("morecredits").style.display = "block";
                    //}
                }
            });
            document.getElementById("hdnCreditsCounter").value = nextPage;
        }


        function loadMoreNews() {
            var userid = getQueryVariableUserId();
            var hdnNewsCounter = document.getElementById("hdnNewsCounter").value;
            var nextPage = parseInt(hdnNewsCounter) + 1;

            $.ajax({
                type: "POST",
                //url: "loadMoreNews",
                data: JSON.stringify({ nextPage: nextPage, userId: userid }),
                url: "/profileMethods.asmx/loadMoreNews",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    if (data.d != "") {
                        $("#newslist").append(data.d);
                        //document.getElementById("morenews").style.display = "block";
                    }

                }
            });

            $.ajax({
                type: "POST",
                //url: "loadMoreNews",
                data: JSON.stringify({ nextPage: nextPage, userId: userid }),
                url: "/profileMethods.asmx/checkmoreAvailableNews",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == 0) {
                        document.getElementById("morenews").style.display = "none";
                    }
                    //else {
                    //    document.getElementById("morenews").style.display = "block";
                    //}
                }
            });

            document.getElementById("hdnNewsCounter").value = nextPage;
        }


        function loadMoreAwards() {
            //var userid = getQueryVariable("userId");
            var userid = getQueryVariableUserId();
            var hdnNewsCounter = document.getElementById("hdnAwardsCounter").value;
            var nextPage = parseInt(hdnNewsCounter) + 1;

            $.ajax({
                type: "POST",
                //url: "profile5.aspx/loadMoreAwards",
                url: "/profileMethods.asmx/loadMoreAwards",
                data: JSON.stringify({ nextPage: nextPage, userId: userid }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != "") {
                        $("#AwardsList").append(data.d);
                        //document.getElementById("MoreAwards").style.display = "block";
                    }
                }

            });

            $.ajax({
                type: "POST",
                //url: "loadMoreNews",
                data: JSON.stringify({ nextPage: nextPage, userId: userid }),
                url: "/profileMethods.asmx/checkmoreAvailableAwards",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == 0) {
                        document.getElementById("MoreAwards").style.display = "none";
                    }
                    //else {
                    //    document.getElementById("MoreAwards").style.display = "block";
                    //}
                }
            });
            document.getElementById("hdnAwardsCounter").value = nextPage;
        }
        var userid = getQueryVariableUserId();
        $('#myModal').on('shown.bs.modal', function (e) {
            val1 = randomNumber(1, 100);
            val2 = randomNumber(1, 200);
            var randomstr = makerandom();
            $('#captchaOperation').html(randomstr);
            //$('#captchaOperation').html([val1, '+', val2, '='].join(' '));

            //$('#hdncaptcha').val(parseInt(val1) + parseInt(val2));
            $('#hdncaptcha').val(randomstr);
            $('#hdnusername').val(userid);
        })
        function makerandom() {
            var text = "";
            var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            for (var i = 0; i < 5; i++)
                text += possible.charAt(Math.floor(Math.random() * possible.length));

            return text;
        }

        function randomNumber(min, max) {
            return Math.floor(Math.random() * (max - min + 1) + min);
        };


        function sendMail() {
            document.getElementById("error").style.display = "none";
            if (document.getElementById("hdncaptcha").value != document.getElementById("captcha").value) {
                document.getElementById("error").style.display = "block";
                return false;
            }
            else {
                var userid = getQueryVariableUserId();
                var fromname = document.getElementById("fromname").value;
                var email = document.getElementById("email").value;
                var subject = document.getElementById("subject").value;
                var message = document.getElementById("message").value;

                $.ajax({
                    type: "POST",
                    //url: "loadMoreNews",
                    data: JSON.stringify({ userid: userid, fromname: fromname, email: email, subject: subject, message: message }),
                    url: "/profileMethods.asmx/sendEmail",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        document.getElementById("modalbody").innerHTML = "Message Sent";
                    },
                    error: function (textStatus, errorThrown) {

                    }
                });
            }
        }



        //$(window).scroll(function () {
        //    var elmnt = document.getElementById("songs");
        //    var y = elmnt.scrollHeight;
        //    if (y > 600) {
                
        //    }
            
        //});
    </script>


    <script>

        $(document).ready(function () {
            $(".bio-more-btn").click(function () {
                $(".user-more-info").show();
            });
            $(".mobile-bio-close").click(function () {
                $(".user-more-info").hide();
            });

           // loadSongs();
        });

    </script>

</body>
</html>
