<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ADVIEWER._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <link href="../Styles/Slider/royalslider.css" rel="stylesheet">
    <script src="../Styles/Slider/jquery.royalslider.min.js?v=9.3.6"></script>      
    <link href="../Styles/Slider/rs-minimal-white.css?v=1.0.4" rel="stylesheet">
            <script type="text/javascript">
    $(window).load(function () { //jQuery(window).load() must be used instead of jQuery(document).ready() because of Webkit compatibility				

        // Carousel > Demo #2
        $(".carousel-demo2").sliderkit({
            shownavitems: 7,
            scroll: 5,
            circular: true,
            start: 2
        });

        // Tabs > Imbricated
        $(".tabs-imbricate").sliderkit({
            cssprefix: "customtabs",
            auto: false,
            tabs: true
        });

    });	
            </script>
            <script>
                jQuery(document).ready(function ($) {
                    $('#full-width-slider').royalSlider({
                        arrowsNav: true,
                        loop: false,
                        keyboardNavEnabled: true,
                        controlsInside: false,
                        imageScaleMode: 'fill',
                        arrowsNavAutoHide: false,
                        autoScaleSlider: true,
                        autoScaleSliderWidth: 960,
                        autoScaleSliderHeight: 350,
                        controlNavigation: 'bullets',
                        thumbsFitInViewport: false,
                        navigateByClick: true,
                        startSlideId: 0,
                        autoPlay: false,
                        transitionType: 'move',
                        globalCaption: true,
                        deeplinking: {
                            enabled: true,
                            change: false
                        },
                        /* size of all images http://help.dimsemenov.com/kb/royalslider-jquery-plugin-faq/adding-width-and-height-properties-to-images */
                        imgWidth: 1400,
                        imgHeight: 680
                    });
                });

    </script>
  
    <div class="sliderContainer fullWidth clearfix" style="overflow:hidden;">
<div id="full-width-slider" class="royalSlider heroSlider rsMinW">
  <div class="rsContent">
    <img class="rsImg" src="../Styles/Slider/2.jpg" alt="" />
    <div class="infoBlock infoBlockLeftBlack rsABlock" data-fade-effect="" data-move-offset="10" data-move-effect="bottom" data-speed="200">
      <h4 style="font-size:25px;color:Black">سایت تبلیغاتی تبلیغ نما</h4>
    </div>
  </div>
  <div class="rsContent">
    <img class="rsImg" src="../Styles/Slider/1.jpg" alt="" />
     
  </div>
 <div class="rsContent">
    <img class="rsImg" src="../Styles/Slider/3.jpg" alt="" />
    
  </div>
  <div class="rsContent">
    <img class="rsImg" src="../Styles/Slider/4.jpg" alt="" />
    <span class="photosBy rsAbsoluteEl" data-fade-effect="fa;se" data-move-offset="40" data-move-effect="bottom" data-speed="200">Photos by <a href="http://www.flickr.com/photos/gilderic/">Gilderic</a></span>
  </div>
</div>
  </div>
</asp:Content>
