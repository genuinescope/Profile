<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="SongCatelogApp.profile1" %>

<!DOCTYPE html>
<html lang="en-US" class="html_stretched responsive av-preloader-disabled av-default-lightbox  html_header_top html_logo_left html_main_nav_header html_menu_right html_slim html_header_sticky html_header_shrinking html_header_topbar_active html_mobile_menu_phone html_disabled html_header_searchicon html_content_align_center html_header_unstick_top_disabled html_header_stretch_disabled html_entry_id_8661 ">
    <head>
        <meta charset="UTF-8" />
        <meta name="robots" content="index, follow" />


        <!-- mobile setting -->
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

        <!-- Scripts/CSS and wp_head hook -->
        <title>Playlist with Waveforms</title>


        <script type='text/javascript' src='js/jquery.js?ver=1.12.4'></script>
        <script type='text/javascript'>
            /* <![CDATA[ */
            var GmediaGallery = {};
            /* ]]> */
        </script>

        <link href="css/styles.css" media="all" type="text/css" rel="stylesheet">
        <link href="css/wavesurfer.css" media="all" type="text/css" rel="stylesheet">
    </head>


  
   <body id="top" class="page-template-default page page-id-8661 page-child parent-pageid-8379 stretched open_sans " itemscope="itemscope" itemtype="https://schema.org/WebPage" >


        <div id='wrap_all'>



            <div id='main' class='all_colors' data-scroll-offset='88'>


                <div id='av_section_2' class='avia-section main_color avia-section-default avia-no-border-styling avia-bg-style-scroll  avia-builder-el-3  el_after_av_section  el_before_av_section   container_wrap fullsize'   ><div class='container' >
                        <div class='template-page content  av-content-full alpha units'>
                            <div class='post-entry post-entry-type-page post-entry-8661'>
                                <div class='entry-content-wrapper clearfix'>
                                    <section class="av_textblock_section"  itemscope="itemscope" itemtype="https://schema.org/CreativeWork" >
                                        <div class='avia_textblock '   itemprop="text" >
                                            <input type="hidden" name="counter" id="counter" value="3">
                                            <input type="hidden" name="loadtimes" id="loadtimes" value="0">
                                            <div id="waveform" style="display:none"></div>
                                              <div id="body_content" runat="server">  
                                           

                                                </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div><!-- close content main div -->
                    </div>
                </div>
                <!--end builder template-->
            </div><!-- close default .container_wrap element -->		







            <!-- end main -->
        </div>

        <!-- end wrap_all --></div>

    <!-- Start of StatCounter Code -->
    <script type='text/javascript' src='wavesurfer2/wavesurfer.min.js?ver=1.2.8'></script>
    <script type='text/javascript' src='wavesurfer2/wavesurfer.js?ver=1.7'></script>
       <script type='text/javascript' src='wavesurfer/wavesurfer.min.js?ver=1.2.8'></script>
    <script type='text/javascript' src='wavesurfer/wavesurfer.js?ver=1.7'></script>
  <script type="text/javascript">

      jQuery(function ($) {

          $.ajax({
              type: "POST",
              url: "profile.aspx/saveWaves",
              data: JSON.stringify({ userId: '5' }),
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (data) {

                  // var json = $.parseJSON(data);
                  obj = JSON && JSON.parse(data.d) || $.parseJSON(data.d);
                  //now json variable contains data in json format
                  //let's display a few items

                  for (var i = 0; i < obj.length; ++i) {
                      //console.log(obj[i].id);
                      setTimeout(function () {
                          var wavesurfer = Object.create(WaveSurfer);
                          var songid = 'Hit_Songs/' + obj[i].id + '.mp3';
                          options = {
                              container: document.querySelector('#waveform'),
                              waveColor: 'blue',
                              progressColor: 'black',
                              height: 78,
                              barWidth: 2,
                              backend: 'WebAudio',
                              cursorWidth: 0,
                              normalize: true,
                              interact: false,
                              gmProgressWave: true
                          };
                          wavesurfer.init(options);
                          wavesurfer.load(songid);
                          wavesurfer.on('ready', function () {
                              alert(1);
                              var pcmData = wavesurfer.exportPCM(1800, 10000, false);
                              if (pcmData) {
                                  this.updateWave(songid, pcmData);
                              }
                              
                            //  console.log(songid);
                            //  console.log(pcmData);
                          });
                      }, 5000);
                  }
              }

          });


          function updateWave(songid, pcmData) {
              $.ajax({
                  type: "POST",
                  url: "profile.aspx/updateWaves",
                  data: JSON.stringify({ songid: songid, pcmData: pcmData }),
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (data) {
                     
                  }

              });

          }
        //  var settings = { "compact_list": "2", "color1": "E20606", "ID": 706, "nonce": "", "url": "", "moduleUrl": "" };
         // $('#GmediaGallery_706').gmWaveSurfer(settings);
         
        
   
      });



  </script>

</body>

</html>
