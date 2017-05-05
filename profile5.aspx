<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile5.aspx.cs" Inherits="SongCatelogApp.profile5" %>

<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <!-- Bootstrap Core CSS -->
       <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900" rel="stylesheet">
   <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css'>

    <link rel="stylesheet" href="/css/font-awesome.min.css">
    <link href="/css/custom.css?v=15_4_2017" rel="stylesheet" />
        <link href="/css/wavesurfer.css" rel="stylesheet" />
            <script type='text/javascript' src='/js/jquery.js?ver=1.12.4'></script><script>jQueryWP = jQuery;</script>
        <script type='text/javascript'>
            /* <![CDATA[ */
            var GmediaGallery = {};
            /* ]]> */
        </script>
 
  
</head>
<body>
    <form runat="server">
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
                    <li>
                        <a runat="server" href="" id="lnkFeatured">Featured Songs</a>
                    </li>
                    <li>
                        <a runat="server" href="" id="lblPlaylists">Playlists</a>
                    </li>
                    <li class="">
                        <a runat="server" href="" id="lnkAllSongs">All Songs</a>
                    </li>
                   
                  
                    <li class="user-contact-msg">
                       <a data-toggle="modal"  data-target="#myModal" > <i class="fa fa-envelope" aria-hidden="true"></i></a>
                    </li>
                </ul>


            



                <%-- <h3>  <asp:LinkButton ID="lnkAllSongs" runat="server"  CommandArgument='121' OnCommand="Button1_Click"   /></h3>
                   
                        <%--<a href="#2a" data-toggle="tab">Playlists</a>--%>
                

                <%--<li onclick="FeaturedRunScript()"><a href="#3a" data-toggle="tab" >Featured</a>--%>
                <%--<h3><asp:LinkButton ID="lnkFeatured" runat="server" onClick="Button1_Click" Text="Featured" CustomParameter="Value2"  /></h3>--%>
            </div>


            <div class="row main-sec">
                <div class="col-sm-9 user-songs">

                    <div class="tab-content clearfix user-songs-tab">

                        <div id="songs" runat="server">
                                <div id="playlistDetails" runat="server"></div>

                            <div class="gmedia_gallery wavesurfer_module" id="GmediaGallery_80" data-gmid="80" data-module="wavesurfer">

                                  <div class="ws-soundList">
                                    <asp:Panel runat="server" ID="pnlMySong">
                                        

                                        <asp:Repeater ID="RtMysongs" runat="server" OnItemDataBound="refeed_OnItemDataBound">
                                            <ItemTemplate>
                                                
                                                <div class="song-details sdetails" id="sDetails" runat="server">
                                                    <div id="genre" runat="server" class="genreList" ></div>
                                                    </span></a>
                                                     <asp:HiddenField ID="hSongID" runat="server" Value='<%#  DataBinder.Eval(Container.DataItem, "id") %>' />
                                                    <asp:HyperLink  ID="lnkSongDetails" CssClass="song-meta-details"  runat="server" NavigateUrl="javascript:void(0)" /> 
                                                    <div class="ws-soundList__item ws-have-cover" data-id="<%# DataBinder.Eval(Container.DataItem, "id")%>">
                                                        <div role="group" class="ws-sound">

                                                            <div class="ws-sound__body">
                                                                <div class="ws-sound__artwork" >
                                                                 <a  class="ws-sound__coverArt"  data-cover="background-image: url('<%# "http://app.hitlicense.com"+DataBinder.Eval(Container.DataItem, "imgpath") %>');">
                                                                        <span class="ws-image ws-artwork ws-artwork-placeholder">
                                                                            <span style="background-image: url('<%# "http://app.hitlicense.com"+DataBinder.Eval(Container.DataItem, "imgpath")  %>');" class="ws-artwork ws-image__thumb"></span>
                                                                        </span>
                                                                    </a>
                                                                </div>

                                                                <div class="ws-sound__content">
                                                                    <div class="ws-visualSound__wrapper ">
                                                                        <div class="ws-sound__header">
                                                                            <div class="ws-soundTitle ws-clearfix">
                                                                                <div class="ws-soundTitle__titleContainer">
                                                                                    <div class="ws-soundTitle__playButton">

                                                                                        <span class="ws-button ws-button-play" tabindex="0" title="Play">Play</span>
                                                                                    </div>

                                                                                    <div class="ws-soundTitle__titleWrapper">
                                                                                        <a class="ws-soundTitle__title ws-link-dark">
                                                                                        <span><%# DataBinder.Eval(Container.DataItem, "songTitle")%></span>
                                                                                </a>
                                                                                         <div class="ws-soundTitle__secondary ws-type-light"><span><%# DataBinder.Eval(Container.DataItem, "artist")%></span></div> 
                                                                                        
                                                                               
                                                                                  
                                                                                        
                                                                                       
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="ws-sound__waveform">
                                                                            <div class="ws-waveform">
                                                                                <div class="ws-waveform__layer veryfirst" data-key="ws<%# DataBinder.Eval(Container.DataItem, "id")%>" data-file="http://app.hitlicense.com/Hit_Songs/<%# DataBinder.Eval(Container.DataItem, "id")%>.mp3" data-peaks='<%#Eval("peakval")%>'>
                                                                                    <wave></wave>
                                                                                </div>
                                                                                <div class="ws-waveform__time">
                                                                                    <span class="ws-time ws-wave_time"></span>
                                                                                    <span class="ws-time ws-track_time"><%# DataBinder.Eval(Container.DataItem, "duration")%></span>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>


                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <div id="pagination">
                                            <div class="light-theme">


                                                <asp:PlaceHolder ID="plcPagingb" runat="server" />
                                            </div>
                                        </div>

                                    </asp:Panel>


                                </div>
                                <div class="ws-soundCompactList"></div>


                            </div>
                        </div>

                        <div runat="server" id="playlists"></div>


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


                    <div id="videosphotos" runat="server">
                    <div class="videotitle"><asp:Label runat="server" ID="lblVideoTitle"></asp:Label></div>


                    <div class="most-view-sec" id="videosdiv" runat="server">
                        <%--<h3>Most Viewed</h3>--%>
                        <div class="youtube-videos">

                            <div class="carousel slide multi-item-carousel-videos" id="theCarouselVideos" data-interval="false">

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
                              <div >
                                  <div id="divPhotos"  runat="server">
                                      <!--  Example item end -->


                                  </div>
                                 </div>
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
                                <ul class='nav nav-pills pop-nav' id="manageSongsTabs">
                                            <li class='active'><a data-toggle='tab' href='#vis_Basic'   >Basic Info</a>
                                            </li>
                                            <li><a data-toggle='tab' href='#vis_MetaData'>Admin Info</a>
                                            </li>
                                           <li><a data-toggle='tab' href='#vis_MetaDataLyrics'>Lyrics</a>
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
                        <input type="text" name="fromname" id="fromname" class="form-control"  required="required" data-error="Firstname is required.">
                        <div class="help-block with-errors"></div>
                    </div>
                </div>
                                <div class="col-md-12">
                    <div class="form-group">
                        <label for="form_email">Email *</label>
                        <input  type="email" name="email" id="email" class="form-control"  required="required" data-error="Valid email is required.">
                        <div class="help-block with-errors"></div>
                    </div>
                </div>
                
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="form_lastname">Subject *</label>
                        <input  type="text" name="subject" id="subject" class="form-control"  required="required" data-error="Subject is required.">
                        <div class="help-block with-errors"></div>
                    </div>
                </div>
                
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="form_message">Message *</label>
                        <textarea  name="message" class="form-control" id="message"  rows="4" required="required" data-error="Please,leave us a message."></textarea>
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


    <footer>

        <p> Powered by <a href="http://www.hitlicense.com/">Hitlicense</a></p>
    </footer>
    <!-- /.container -->
        <!-- jQuery Version 1.11.1 -->
    <script src="/js/jquery.js"></script>

    <script type='text/javascript' src='/wavesurfer4/wavesurfer.min.js?ver=1.2.8'></script>
    <script type='text/javascript' src='/wavesurfer4/wavesurfer.js?ver=1.7'></script>
    <script type="text/javascript">
        jQuery(function ($) {
            var settings = { "show_big_cover": "1", "show_download_button": "1", "link_button_text": "Link Button", "color1": "25B4D1", "color2": "878787", "color3": "23728A", "color4": "D1E5EB", "ID": 80, "nonce": "513961313f", "url": "", "moduleUrl": "" };
            $('#GmediaGallery_80').gmWaveSurfer(settings);
        });


    </script>
    <!-- Bootstrap Core JavaScript -->
    <script src='//cdnjs.cloudflare.com/ajax/libs/jquery/2.2.2/jquery.min.js'></script>
    <script src='//maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js'></script>



    <script>        // Instantiate the Bootstrap carousel

        //$('#theCarouselVideos').carousel({
        //    interval: 4000
        //})

       
        $('.multi-item-carousel-videos .item').each(function () {
            var next = $(this).next();
            if (!next.length) {
                next = $(this).siblings(':first');
            }
            next.children(':first-child').clone().appendTo($(this));

             /*for (var i = 0; i < 1; i++) {
                next = next.next();
                if (!next.length) {
                    next = $(this).siblings(':first');
                }*/

                next.children(':first-child').clone().appendTo($(this));
            }
        });

        //$('#theCarouselPhotos').carousel({
        //    interval: 4000
        //})

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
      
    </script>
    <script type="text/javascript">
        function songDetails(songid) {

            var modal = document.getElementById('myModalmetadata');
            modal.style.display = "block";
            PopulateBasicData(songid);
            PopulateMetaData(songid);
            PopulateLyrics(songid);

            setFirstTabDisplay();
            return false;
        }

        function setFirstTabDisplay() {
            $("#manageSongsTabs li").removeClass("active");
            $("#manageSongsTabs li:first").attr("class", "active");

            $("#vis_Basic").addClass("tab-pane fade active in");
            $("#vis_MetaData").addClass("tab-pane fade");
            $("#vis_MetaDataLyrics").addClass("tab-pane fade");
            

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
            var displayBio = strBio.substr(0,300);
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
                    var bioDisplay = nl2br(data.d,false);
                    $("#lblBio").html(bioDisplay);
                    $("#bioMore").attr("style", "display:none");
                    $("#bioLess").attr("style", "display:block");

                }

            });
        }

        
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
                data: JSON.stringify({ nextPage: nextPage, userId:userid }),
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

        function paging() {
            alert(2323);
        }
    </script>


    <script>
      
        $(".bio-more-btn").click(function () {
          //  alert('open');
            $(".user-more-info").show();
        });
        $(".mobile-bio-close").click(function () {
          //  alert('close');
            $(".user-more-info").hide();
        });
        
        $(document).ready(function(){
           
        });

    </script>

</body>
</html>
