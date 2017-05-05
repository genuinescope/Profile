<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="peaks.aspx.cs" Inherits="SongCatelogApp.peaks" %>

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



          <div id="waveform"></div>



            <!-- end main -->
        </div>

        <!-- end wrap_all --></div>

    <!-- Start of StatCounter Code -->
    <script type='text/javascript' src='wavesurfer/wavesurfer.min.js?ver=1.2.8'></script>
    <script type='text/javascript' src='wavesurfer/wavesurfer.js?ver=1.7'></script>
  <script type="text/javascript">
      var wavesurfer = Object.create(WaveSurfer);
      var songid = 'Hit_Songs/80631.mp3';
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
          var pcmData = wavesurfer.exportPCM(1800, 10000, true);
          console.log(songid);
          console.log(pcmData);
      });

  </script>

</body>

</html>
