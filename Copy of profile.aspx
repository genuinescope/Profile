<%@ Page Language="C#" AutoEventWireup="true" Inherits="SongCatelogApp.profile" Codebehind="profile.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="./bootstrap/bootstrap.css" rel="stylesheet" />
        <link rel='stylesheet' type="text/css" href="style/style.css"/>
        <script src="js/jquery.js" type="text/javascript"></script>

        <link rel='stylesheet' type="text/css" href="dzstooltip/dzstooltip.css"/>
        <link rel='stylesheet' type="text/css" href="audioplayer/audioplayer.css"/>
        <script src="audioplayer/audioplayer.js" type="text/javascript"></script>
</head>
<body>




        <div class="container prof-view-container">
        
        <div class="profile-cover" style="background: url('https://s3.amazonaws.com/themusicbed/files/production/playlists/54510/1ca3aaf1038e31a1f072fdbe74dfced0ea40f876.png') center center no-repeat;">
            <div class="cover-info">
                <div class="user-prof-img">
                    <%--<img id="Img1" src="http://app.hitlicense.com/Profile_Image/10394.jpg" />--%>
                    <asp:Image runat="server"  ID="ProfilePic" /> 
                </div>

                <div class="user-detail">
                    <h1><asp:Label ID="txtName" runat="server"></asp:Label></h1>
                    <h3><asp:Label ID="txtEmail" runat="server" ></asp:Label></h3>
                    <h3><asp:Label ID="txtPhone" runat="server" ></asp:Label></h3>
                </div>

            </div>

        </div>
        
        <div class="user-songs-container">

            <div class="row">
                <div class="col-md-8 user-song-list">
                    <div runat="server" id="body_content"></div>
                </div>
                <div class="col-md-4 user-song-album">
                    <h4>Albums</h4>

                    <div class="row">
                        <div class="col-md-6 col-sm-3 col-xs-6 user-album-image">
                            <img src="https://s3.amazonaws.com/themusicbed/files/production/albums/57451/500.a0b3d4294c949bda7333ab7b7964e56581b7c3b3.jpg">
                        </div>
                        <div class="col-md-6 col-sm-3 col-xs-6 user-album-image">
                            <img src="https://s3.amazonaws.com/themusicbed/files/production/albums/66881/500.215f82d404fdbc06b605691e70a3ffbd9e544d1c.jpg">
                        </div>
                        
                        <div class="col-md-6 col-sm-3 col-xs-6 user-album-image">
                            <img src="https://s3.amazonaws.com/themusicbed/files/production/albums/44269/500.d95ba8b4f7a86faf4caaab9c5521fb69c4ac203a.jpg">
                        </div>
                        <div class="col-md-6 col-sm-3 col-xs-6 user-album-image">
                            <img src="https://s3.amazonaws.com/themusicbed/files/production/albums/17872/500.9d69ef6a3f98a1c27c881575a73bb8858997fd8d.jpg">
                        </div>
                    </div>

                    <h4> Bio </h4>
                    <p>
                        The ability to strike emotion on a universal level, to touch the heart without words, to transport you to a place where anything and everything is possible...this is the power of cinematic post-rock powerhouse LIGHTS & MOTION. The level of emotional intricacy achieved by the band's braintrust and solo composer, Christoffer Franzen, is nothing short of remarkable. This is not only music you can hear, it's music you can see and feel. From flawless guitar structures to beautiful piano melodies, the ebb and flow of each track is brilliantly orchestrated. From spots on The Academy Awards and Super Bowl to Hollywood movie trailers, hit TV shows and viral videos, the music of LIGHTS & MOTION inspires feelings of awe and wonder due to its uniquely accessible, timeless and captivating nature.
                    </p>

                </div>
            </div>

            
        </div>




    </div>


                  

    <script>
        jQuery(document).ready(function ($) {
            var settings_ap = {
                disable_volume: 'off'
                , disable_scrub: 'default'
                , design_skin: 'skin-wave'
                , skinwave_dynamicwaves: 'off'
                , skinwave_enableSpectrum: 'off'
                , settings_backup_type: 'full'
                , skinwave_enableReflect: 'on'
                , skinwave_comments_enable: 'on'
            };
            dzsag_init('#ag1', {
                'transition': 'fade'
                , 'autoplay': 'on'
                , 'autoplayNext': 'on'
                , design_menu_position: 'bottom'
                , 'settings_ap': settings_ap
                , design_menu_state: 'closed'
                , design_menu_show_player_state_button: 'on'
            });
        });
        </script>
</body>
</html>
