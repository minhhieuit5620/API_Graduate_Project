using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;

namespace ISCommon.Utility
{
    public static class ISFile
    {
        private static IDictionary<string, string> _mappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase) {

        #region Big freaking list of mime types
        // combination of values from Windows 7 Registry and 
        // from C:\Windows\System32\inetsrv\config\applicationHost.config
        // some added, including .7z and .dat
        {".323", "text/h323"},
        {".3g2", "video/3gpp2"},
        {".3gp", "video/3gpp"},
        {".3gp2", "video/3gpp2"},
        {".3gpp", "video/3gpp"},
        {".7z", "application/x-7z-compressed"},
        {".aa", "audio/audible"},
        {".AAC", "audio/aac"},
        {".aaf", "application/octet-stream"},
        {".aax", "audio/vnd.audible.aax"},
        {".ac3", "audio/ac3"},
        {".aca", "application/octet-stream"},
        {".accda", "application/msaccess.addin"},
        {".accdb", "application/msaccess"},
        {".accdc", "application/msaccess.cab"},
        {".accde", "application/msaccess"},
        {".accdr", "application/msaccess.runtime"},
        {".accdt", "application/msaccess"},
        {".accdw", "application/msaccess.webapplication"},
        {".accft", "application/msaccess.ftemplate"},
        {".acx", "application/internet-property-stream"},
        {".AddIn", "text/xml"},
        {".ade", "application/msaccess"},
        {".adobebridge", "application/x-bridge-url"},
        {".adp", "application/msaccess"},
        {".ADT", "audio/vnd.dlna.adts"},
        {".ADTS", "audio/aac"},
        {".afm", "application/octet-stream"},
        {".ai", "application/postscript"},
        {".aif", "audio/x-aiff"},
        {".aifc", "audio/aiff"},
        {".aiff", "audio/aiff"},
        {".air", "application/vnd.adobe.air-application-installer-package+zip"},
        {".amc", "application/x-mpeg"},
        {".application", "application/x-ms-application"},
        {".art", "image/x-jg"},
        {".asa", "application/xml"},
        {".asax", "application/xml"},
        {".ascx", "application/xml"},
        {".asd", "application/octet-stream"},
        {".asf", "video/x-ms-asf"},
        {".ashx", "application/xml"},
        {".asi", "application/octet-stream"},
        {".asm", "text/plain"},
        {".asmx", "application/xml"},
        {".aspx", "application/xml"},
        {".asr", "video/x-ms-asf"},
        {".asx", "video/x-ms-asf"},
        {".atom", "application/atom+xml"},
        {".au", "audio/basic"},
        {".avi", "video/x-msvideo"},
        {".axs", "application/olescript"},
        {".bas", "text/plain"},
        {".bcpio", "application/x-bcpio"},
        {".bin", "application/octet-stream"},
        {".bmp", "image/bmp"},
        {".c", "text/plain"},
        {".cab", "application/octet-stream"},
        {".caf", "audio/x-caf"},
        {".calx", "application/vnd.ms-office.calx"},
        {".cat", "application/vnd.ms-pki.seccat"},
        {".cc", "text/plain"},
        {".cd", "text/plain"},
        {".cdda", "audio/aiff"},
        {".cdf", "application/x-cdf"},
        {".cer", "application/x-x509-ca-cert"},
        {".chm", "application/octet-stream"},
        {".class", "application/x-java-applet"},
        {".clp", "application/x-msclip"},
        {".cmx", "image/x-cmx"},
        {".cnf", "text/plain"},
        {".cod", "image/cis-cod"},
        {".config", "application/xml"},
        {".contact", "text/x-ms-contact"},
        {".coverage", "application/xml"},
        {".cpio", "application/x-cpio"},
        {".cpp", "text/plain"},
        {".crd", "application/x-mscardfile"},
        {".crl", "application/pkix-crl"},
        {".crt", "application/x-x509-ca-cert"},
        {".cs", "text/plain"},
        {".csdproj", "text/plain"},
        {".csh", "application/x-csh"},
        {".csproj", "text/plain"},
        {".css", "text/css"},
        {".csv", "text/csv"},
        {".cur", "application/octet-stream"},
        {".cxx", "text/plain"},
        {".dat", "application/octet-stream"},
        {".datasource", "application/xml"},
        {".dbproj", "text/plain"},
        {".dcr", "application/x-director"},
        {".def", "text/plain"},
        {".deploy", "application/octet-stream"},
        {".der", "application/x-x509-ca-cert"},
        {".dgml", "application/xml"},
        {".dib", "image/bmp"},
        {".dif", "video/x-dv"},
        {".dir", "application/x-director"},
        {".disco", "text/xml"},
        {".dll", "application/x-msdownload"},
        {".dll.config", "text/xml"},
        {".dlm", "text/dlm"},
        {".doc", "application/msword"},
        {".docm", "application/vnd.ms-word.document.macroEnabled.12"},
        {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
        {".dot", "application/msword"},
        {".dotm", "application/vnd.ms-word.template.macroEnabled.12"},
        {".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template"},
        {".dsp", "application/octet-stream"},
        {".dsw", "text/plain"},
        {".dtd", "text/xml"},
        {".dtsConfig", "text/xml"},
        {".dv", "video/x-dv"},
        {".dvi", "application/x-dvi"},
        {".dwf", "drawing/x-dwf"},
        {".dwp", "application/octet-stream"},
        {".dxr", "application/x-director"},
        {".eml", "message/rfc822"},
        {".emz", "application/octet-stream"},
        {".eot", "application/octet-stream"},
        {".eps", "application/postscript"},
        {".etl", "application/etl"},
        {".etx", "text/x-setext"},
        {".evy", "application/envoy"},
        {".exe", "application/octet-stream"},
        {".exe.config", "text/xml"},
        {".fdf", "application/vnd.fdf"},
        {".fif", "application/fractals"},
        {".filters", "Application/xml"},
        {".fla", "application/octet-stream"},
        {".flr", "x-world/x-vrml"},
        {".flv", "video/x-flv"},
        {".fsscript", "application/fsharp-script"},
        {".fsx", "application/fsharp-script"},
        {".generictest", "application/xml"},
        {".gif", "image/gif"},
        {".group", "text/x-ms-group"},
        {".gsm", "audio/x-gsm"},
        {".gtar", "application/x-gtar"},
        {".gz", "application/x-gzip"},
        {".h", "text/plain"},
        {".hdf", "application/x-hdf"},
        {".hdml", "text/x-hdml"},
        {".hhc", "application/x-oleobject"},
        {".hhk", "application/octet-stream"},
        {".hhp", "application/octet-stream"},
        {".hlp", "application/winhlp"},
        {".hpp", "text/plain"},
        {".hqx", "application/mac-binhex40"},
        {".hta", "application/hta"},
        {".htc", "text/x-component"},
        {".htm", "text/html"},
        {".html", "text/html"},
        {".htt", "text/webviewhtml"},
        {".hxa", "application/xml"},
        {".hxc", "application/xml"},
        {".hxd", "application/octet-stream"},
        {".hxe", "application/xml"},
        {".hxf", "application/xml"},
        {".hxh", "application/octet-stream"},
        {".hxi", "application/octet-stream"},
        {".hxk", "application/xml"},
        {".hxq", "application/octet-stream"},
        {".hxr", "application/octet-stream"},
        {".hxs", "application/octet-stream"},
        {".hxt", "text/html"},
        {".hxv", "application/xml"},
        {".hxw", "application/octet-stream"},
        {".hxx", "text/plain"},
        {".i", "text/plain"},
        {".ico", "image/x-icon"},
        {".ics", "application/octet-stream"},
        {".idl", "text/plain"},
        {".ief", "image/ief"},
        {".iii", "application/x-iphone"},
        {".inc", "text/plain"},
        {".inf", "application/octet-stream"},
        {".inl", "text/plain"},
        {".ins", "application/x-internet-signup"},
        {".ipa", "application/x-itunes-ipa"},
        {".ipg", "application/x-itunes-ipg"},
        {".ipproj", "text/plain"},
        {".ipsw", "application/x-itunes-ipsw"},
        {".iqy", "text/x-ms-iqy"},
        {".isp", "application/x-internet-signup"},
        {".ite", "application/x-itunes-ite"},
        {".itlp", "application/x-itunes-itlp"},
        {".itms", "application/x-itunes-itms"},
        {".itpc", "application/x-itunes-itpc"},
        {".IVF", "video/x-ivf"},
        {".jar", "application/java-archive"},
        {".java", "application/octet-stream"},
        {".jck", "application/liquidmotion"},
        {".jcz", "application/liquidmotion"},
        {".jfif", "image/pjpeg"},
        {".jnlp", "application/x-java-jnlp-file"},
        {".jpb", "application/octet-stream"},
        {".jpe", "image/jpeg"},
        {".jpeg", "image/jpeg"},
        {".jpg", "image/jpeg"},
        {".js", "application/x-javascript"},
        {".jsx", "text/jscript"},
        {".jsxbin", "text/plain"},
        {".latex", "application/x-latex"},
        {".library-ms", "application/windows-library+xml"},
        {".lit", "application/x-ms-reader"},
        {".loadtest", "application/xml"},
        {".lpk", "application/octet-stream"},
        {".lsf", "video/x-la-asf"},
        {".lst", "text/plain"},
        {".lsx", "video/x-la-asf"},
        {".lzh", "application/octet-stream"},
        {".m13", "application/x-msmediaview"},
        {".m14", "application/x-msmediaview"},
        {".m1v", "video/mpeg"},
        {".m2t", "video/vnd.dlna.mpeg-tts"},
        {".m2ts", "video/vnd.dlna.mpeg-tts"},
        {".m2v", "video/mpeg"},
        {".m3u", "audio/x-mpegurl"},
        {".m3u8", "audio/x-mpegurl"},
        {".m4a", "audio/m4a"},
        {".m4b", "audio/m4b"},
        {".m4p", "audio/m4p"},
        {".m4r", "audio/x-m4r"},
        {".m4v", "video/x-m4v"},
        {".mac", "image/x-macpaint"},
        {".mak", "text/plain"},
        {".man", "application/x-troff-man"},
        {".manifest", "application/x-ms-manifest"},
        {".map", "text/plain"},
        {".master", "application/xml"},
        {".mda", "application/msaccess"},
        {".mdb", "application/x-msaccess"},
        {".mde", "application/msaccess"},
        {".mdp", "application/octet-stream"},
        {".me", "application/x-troff-me"},
        {".mfp", "application/x-shockwave-flash"},
        {".mht", "message/rfc822"},
        {".mhtml", "message/rfc822"},
        {".mid", "audio/mid"},
        {".midi", "audio/mid"},
        {".mix", "application/octet-stream"},
        {".mk", "text/plain"},
        {".mmf", "application/x-smaf"},
        {".mno", "text/xml"},
        {".mny", "application/x-msmoney"},
        {".mod", "video/mpeg"},
        {".mov", "video/quicktime"},
        {".movie", "video/x-sgi-movie"},
        {".mp2", "video/mpeg"},
        {".mp2v", "video/mpeg"},
        {".mp3", "audio/mpeg"},
        {".mp4", "video/mp4"},
        {".mp4v", "video/mp4"},
        {".mpa", "video/mpeg"},
        {".mpe", "video/mpeg"},
        {".mpeg", "video/mpeg"},
        {".mpf", "application/vnd.ms-mediapackage"},
        {".mpg", "video/mpeg"},
        {".mpp", "application/vnd.ms-project"},
        {".mpv2", "video/mpeg"},
        {".mqv", "video/quicktime"},
        {".ms", "application/x-troff-ms"},
        {".msi", "application/octet-stream"},
        {".mso", "application/octet-stream"},
        {".mts", "video/vnd.dlna.mpeg-tts"},
        {".mtx", "application/xml"},
        {".mvb", "application/x-msmediaview"},
        {".mvc", "application/x-miva-compiled"},
        {".mxp", "application/x-mmxp"},
        {".nc", "application/x-netcdf"},
        {".nsc", "video/x-ms-asf"},
        {".nws", "message/rfc822"},
        {".ocx", "application/octet-stream"},
        {".oda", "application/oda"},
        {".odc", "text/x-ms-odc"},
        {".odh", "text/plain"},
        {".odl", "text/plain"},
        {".odp", "application/vnd.oasis.opendocument.presentation"},
        {".ods", "application/oleobject"},
        {".odt", "application/vnd.oasis.opendocument.text"},
        {".one", "application/onenote"},
        {".onea", "application/onenote"},
        {".onepkg", "application/onenote"},
        {".onetmp", "application/onenote"},
        {".onetoc", "application/onenote"},
        {".onetoc2", "application/onenote"},
        {".orderedtest", "application/xml"},
        {".osdx", "application/opensearchdescription+xml"},
        {".p10", "application/pkcs10"},
        {".p12", "application/x-pkcs12"},
        {".p7b", "application/x-pkcs7-certificates"},
        {".p7c", "application/pkcs7-mime"},
        {".p7m", "application/pkcs7-mime"},
        {".p7r", "application/x-pkcs7-certreqresp"},
        {".p7s", "application/pkcs7-signature"},
        {".pbm", "image/x-portable-bitmap"},
        {".pcast", "application/x-podcast"},
        {".pct", "image/pict"},
        {".pcx", "application/octet-stream"},
        {".pcz", "application/octet-stream"},
        {".pdf", "application/pdf"},
        {".pfb", "application/octet-stream"},
        {".pfm", "application/octet-stream"},
        {".pfx", "application/x-pkcs12"},
        {".pgm", "image/x-portable-graymap"},
        {".pic", "image/pict"},
        {".pict", "image/pict"},
        {".pkgdef", "text/plain"},
        {".pkgundef", "text/plain"},
        {".pko", "application/vnd.ms-pki.pko"},
        {".pls", "audio/scpls"},
        {".pma", "application/x-perfmon"},
        {".pmc", "application/x-perfmon"},
        {".pml", "application/x-perfmon"},
        {".pmr", "application/x-perfmon"},
        {".pmw", "application/x-perfmon"},
        {".png", "image/png"},
        {".pnm", "image/x-portable-anymap"},
        {".pnt", "image/x-macpaint"},
        {".pntg", "image/x-macpaint"},
        {".pnz", "image/png"},
        {".pot", "application/vnd.ms-powerpoint"},
        {".potm", "application/vnd.ms-powerpoint.template.macroEnabled.12"},
        {".potx", "application/vnd.openxmlformats-officedocument.presentationml.template"},
        {".ppa", "application/vnd.ms-powerpoint"},
        {".ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12"},
        {".ppm", "image/x-portable-pixmap"},
        {".pps", "application/vnd.ms-powerpoint"},
        {".ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12"},
        {".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow"},
        {".ppt", "application/vnd.ms-powerpoint"},
        {".pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12"},
        {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
        {".prf", "application/pics-rules"},
        {".prm", "application/octet-stream"},
        {".prx", "application/octet-stream"},
        {".ps", "application/postscript"},
        {".psc1", "application/PowerShell"},
        {".psd", "application/octet-stream"},
        {".psess", "application/xml"},
        {".psm", "application/octet-stream"},
        {".psp", "application/octet-stream"},
        {".pub", "application/x-mspublisher"},
        {".pwz", "application/vnd.ms-powerpoint"},
        {".qht", "text/x-html-insertion"},
        {".qhtm", "text/x-html-insertion"},
        {".qt", "video/quicktime"},
        {".qti", "image/x-quicktime"},
        {".qtif", "image/x-quicktime"},
        {".qtl", "application/x-quicktimeplayer"},
        {".qxd", "application/octet-stream"},
        {".ra", "audio/x-pn-realaudio"},
        {".ram", "audio/x-pn-realaudio"},
        {".rar", "application/octet-stream"},
        {".ras", "image/x-cmu-raster"},
        {".rat", "application/rat-file"},
        {".rc", "text/plain"},
        {".rc2", "text/plain"},
        {".rct", "text/plain"},
        {".rdlc", "application/xml"},
        {".resx", "application/xml"},
        {".rf", "image/vnd.rn-realflash"},
        {".rgb", "image/x-rgb"},
        {".rgs", "text/plain"},
        {".rm", "application/vnd.rn-realmedia"},
        {".rmi", "audio/mid"},
        {".rmp", "application/vnd.rn-rn_music_package"},
        {".roff", "application/x-troff"},
        {".rpm", "audio/x-pn-realaudio-plugin"},
        {".rqy", "text/x-ms-rqy"},
        {".rtf", "application/rtf"},
        {".rtx", "text/richtext"},
        {".ruleset", "application/xml"},
        {".s", "text/plain"},
        {".safariextz", "application/x-safari-safariextz"},
        {".scd", "application/x-msschedule"},
        {".sct", "text/scriptlet"},
        {".sd2", "audio/x-sd2"},
        {".sdp", "application/sdp"},
        {".sea", "application/octet-stream"},
        {".searchConnector-ms", "application/windows-search-connector+xml"},
        {".setpay", "application/set-payment-initiation"},
        {".setreg", "application/set-registration-initiation"},
        {".settings", "application/xml"},
        {".sgimb", "application/x-sgimb"},
        {".sgml", "text/sgml"},
        {".sh", "application/x-sh"},
        {".shar", "application/x-shar"},
        {".shtml", "text/html"},
        {".sit", "application/x-stuffit"},
        {".sitemap", "application/xml"},
        {".skin", "application/xml"},
        {".sldm", "application/vnd.ms-powerpoint.slide.macroEnabled.12"},
        {".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide"},
        {".slk", "application/vnd.ms-excel"},
        {".sln", "text/plain"},
        {".slupkg-ms", "application/x-ms-license"},
        {".smd", "audio/x-smd"},
        {".smi", "application/octet-stream"},
        {".smx", "audio/x-smd"},
        {".smz", "audio/x-smd"},
        {".snd", "audio/basic"},
        {".snippet", "application/xml"},
        {".snp", "application/octet-stream"},
        {".sol", "text/plain"},
        {".sor", "text/plain"},
        {".spc", "application/x-pkcs7-certificates"},
        {".spl", "application/futuresplash"},
        {".src", "application/x-wais-source"},
        {".srf", "text/plain"},
        {".SSISDeploymentManifest", "text/xml"},
        {".ssm", "application/streamingmedia"},
        {".sst", "application/vnd.ms-pki.certstore"},
        {".stl", "application/vnd.ms-pki.stl"},
        {".sv4cpio", "application/x-sv4cpio"},
        {".sv4crc", "application/x-sv4crc"},
        {".svc", "application/xml"},
        {".swf", "application/x-shockwave-flash"},
        {".t", "application/x-troff"},
        {".tar", "application/x-tar"},
        {".tcl", "application/x-tcl"},
        {".testrunconfig", "application/xml"},
        {".testsettings", "application/xml"},
        {".tex", "application/x-tex"},
        {".texi", "application/x-texinfo"},
        {".texinfo", "application/x-texinfo"},
        {".tgz", "application/x-compressed"},
        {".thmx", "application/vnd.ms-officetheme"},
        {".thn", "application/octet-stream"},
        {".tif", "image/tiff"},
        {".tiff", "image/tiff"},
        {".tlh", "text/plain"},
        {".tli", "text/plain"},
        {".toc", "application/octet-stream"},
        {".tr", "application/x-troff"},
        {".trm", "application/x-msterminal"},
        {".trx", "application/xml"},
        {".ts", "video/vnd.dlna.mpeg-tts"},
        {".tsv", "text/tab-separated-values"},
        {".ttf", "application/octet-stream"},
        {".tts", "video/vnd.dlna.mpeg-tts"},
        {".txt", "text/plain"},
        {".u32", "application/octet-stream"},
        {".uls", "text/iuls"},
        {".user", "text/plain"},
        {".ustar", "application/x-ustar"},
        {".vb", "text/plain"},
        {".vbdproj", "text/plain"},
        {".vbk", "video/mpeg"},
        {".vbproj", "text/plain"},
        {".vbs", "text/vbscript"},
        {".vcf", "text/x-vcard"},
        {".vcproj", "Application/xml"},
        {".vcs", "text/plain"},
        {".vcxproj", "Application/xml"},
        {".vddproj", "text/plain"},
        {".vdp", "text/plain"},
        {".vdproj", "text/plain"},
        {".vdx", "application/vnd.ms-visio.viewer"},
        {".vml", "text/xml"},
        {".vscontent", "application/xml"},
        {".vsct", "text/xml"},
        {".vsd", "application/vnd.visio"},
        {".vsi", "application/ms-vsi"},
        {".vsix", "application/vsix"},
        {".vsixlangpack", "text/xml"},
        {".vsixmanifest", "text/xml"},
        {".vsmdi", "application/xml"},
        {".vspscc", "text/plain"},
        {".vss", "application/vnd.visio"},
        {".vsscc", "text/plain"},
        {".vssettings", "text/xml"},
        {".vssscc", "text/plain"},
        {".vst", "application/vnd.visio"},
        {".vstemplate", "text/xml"},
        {".vsto", "application/x-ms-vsto"},
        {".vsw", "application/vnd.visio"},
        {".vsx", "application/vnd.visio"},
        {".vtx", "application/vnd.visio"},
        {".wav", "audio/wav"},
        {".wave", "audio/wav"},
        {".wax", "audio/x-ms-wax"},
        {".wbk", "application/msword"},
        {".wbmp", "image/vnd.wap.wbmp"},
        {".wcm", "application/vnd.ms-works"},
        {".wdb", "application/vnd.ms-works"},
        {".wdp", "image/vnd.ms-photo"},
        {".webarchive", "application/x-safari-webarchive"},
        {".webtest", "application/xml"},
        {".wiq", "application/xml"},
        {".wiz", "application/msword"},
        {".wks", "application/vnd.ms-works"},
        {".WLMP", "application/wlmoviemaker"},
        {".wlpginstall", "application/x-wlpg-detect"},
        {".wlpginstall3", "application/x-wlpg3-detect"},
        {".wm", "video/x-ms-wm"},
        {".wma", "audio/x-ms-wma"},
        {".wmd", "application/x-ms-wmd"},
        {".wmf", "application/x-msmetafile"},
        {".wml", "text/vnd.wap.wml"},
        {".wmlc", "application/vnd.wap.wmlc"},
        {".wmls", "text/vnd.wap.wmlscript"},
        {".wmlsc", "application/vnd.wap.wmlscriptc"},
        {".wmp", "video/x-ms-wmp"},
        {".wmv", "video/x-ms-wmv"},
        {".wmx", "video/x-ms-wmx"},
        {".wmz", "application/x-ms-wmz"},
        {".wpl", "application/vnd.ms-wpl"},
        {".wps", "application/vnd.ms-works"},
        {".wri", "application/x-mswrite"},
        {".wrl", "x-world/x-vrml"},
        {".wrz", "x-world/x-vrml"},
        {".wsc", "text/scriptlet"},
        {".wsdl", "text/xml"},
        {".wvx", "video/x-ms-wvx"},
        {".x", "application/directx"},
        {".xaf", "x-world/x-vrml"},
        {".xaml", "application/xaml+xml"},
        {".xap", "application/x-silverlight-app"},
        {".xbap", "application/x-ms-xbap"},
        {".xbm", "image/x-xbitmap"},
        {".xdr", "text/plain"},
        {".xht", "application/xhtml+xml"},
        {".xhtml", "application/xhtml+xml"},
        {".xla", "application/vnd.ms-excel"},
        {".xlam", "application/vnd.ms-excel.addin.macroEnabled.12"},
        {".xlc", "application/vnd.ms-excel"},
        {".xld", "application/vnd.ms-excel"},
        {".xlk", "application/vnd.ms-excel"},
        {".xll", "application/vnd.ms-excel"},
        {".xlm", "application/vnd.ms-excel"},
        {".xls", "application/vnd.ms-excel"},
        {".xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12"},
        {".xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12"},
        {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
        {".xlt", "application/vnd.ms-excel"},
        {".xltm", "application/vnd.ms-excel.template.macroEnabled.12"},
        {".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template"},
        {".xlw", "application/vnd.ms-excel"},
        {".xml", "text/xml"},
        {".xmta", "application/xml"},
        {".xof", "x-world/x-vrml"},
        {".XOML", "text/plain"},
        {".xpm", "image/x-xpixmap"},
        {".xps", "application/vnd.ms-xpsdocument"},
        {".xrm-ms", "text/xml"},
        {".xsc", "application/xml"},
        {".xsd", "text/xml"},
        {".xsf", "text/xml"},
        {".xsl", "text/xml"},
        {".xslt", "text/xml"},
        {".xsn", "application/octet-stream"},
        {".xss", "application/xml"},
        {".xtp", "application/octet-stream"},
        {".xwd", "image/x-xwindowdump"},
        {".z", "application/x-compress"},
        {".zip", "application/x-zip-compressed"},
        #endregion

        };



        public static string CreateFileName(string directory, string filename, bool AppendNumberIfNameAlreadyExists = true)
        {
            if (!CheckIfDirectoryExists(directory))
                throw new ArgumentException(string.Format("The specified directory - {0} - does not exist", directory));

            string formatedTemplate = "{0}{1}{2}";
            var fileExtension = Path.GetExtension(filename);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename); 
            

            string newname = String.Format(formatedTemplate, fileNameWithoutExtension, string.Empty, fileExtension);
            string path = Path.Combine(directory, newname);
            int AppendDigit = 0;

            while (AppendNumberIfNameAlreadyExists && CheckIfFilePathExists(path))
            {
                ++AppendDigit;
                newname = String.Format(formatedTemplate, fileNameWithoutExtension, "-" + AppendDigit, fileExtension);
                path = Path.Combine(directory, newname);
            }

            return newname;
        }

        public static bool CheckIfDirectoryExists(string directory)
        {
            return System.IO.Directory.Exists(directory);
        }

        public static bool CheckIfFilePathExists(string path)
        {
            return System.IO.File.Exists(path);
        }

        public static string GetMimeType(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }

            string[] ext = fileName.Split('.');
            string extension = "." +  ext[ext.Length - 1];

            string mime;

            return _mappings.TryGetValue(extension, out mime) ? mime : "application/octet-stream";
        }
        /// <summary>
        ///    Hàm đọc tập tin:
        /// </summary>
        /// <param name="path">Đường dẫn lưu trữ file</param>        
        /// <param name="fileName">Tên file</param>        
        public static int ISOpenText(string path, string fileName, out string data)
        {
            data = "";
            try
            {
                if (File.Exists(path + fileName))
                {
                    // Read the file as one string. 
                    data = System.IO.File.ReadAllText(path + fileName);

                }
                else
                {
                    return -1;
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        ///    Hàm đọc tập tin:
        /// </summary>
        /// <param name="path">Đường dẫn lưu trữ file</param>        
        /// <param name="fileName">Tên file</param>        
        public static int ISOpenLines(string path, string fileName, out string[] data)
        {
            data = null;
            try
            {
                if (File.Exists(path + fileName))
                {
                    // Read each line of the file into a string array. Each element 
                    // of the array is one line of the file. 
                    data = System.IO.File.ReadAllLines(path + fileName);
                }
                else
                {
                    return -1;
                }
                return 1;
            }
            catch {               
                return 0;
            }
        }

        /// <summary>
        ///    Hàm đọc tập tin:
        /// </summary>
        /// <param name="path">Đường dẫn lưu trữ file</param>        
        /// <param name="fileName">Tên file</param>      
        /// <param name="encoding">Encoding</param> 
        public static int ISOpenLines(string path, string fileName, string encoding, out string[] data)
        {
            data = null;
            try
            {
                if (File.Exists(path + fileName))
                {
                    System.Text.Encoding enc = System.Text.Encoding.GetEncoding(encoding);
                    // Read each line of the file into a string array. Each element 
                    // of the array is one line of the file. 
                    data = System.IO.File.ReadAllLines(path + fileName, enc);
                }
                else
                {
                    return -1;
                }
                return 1;
            }
            catch {
                return 0;
            }
        }

        /// <summary>
        ///    Hàm đọc tập tin csv:
        /// </summary>
        /// <param name="path">Đường dẫn lưu trữ file</param>        
        /// <param name="fileName">Tên file</param>      
        /// <param name="encoding">Encoding</param> 
        public static int ISOpenCvs(string path, string fileName, char delimiter, bool header, string encoding, string nullValue, out DataTable data)
        {
            string[] value;
            data = new DataTable();
            int rs = ISOpenLines(path, fileName, encoding, out value);
            if (rs == 1 && value.Count() > 0)
            {
                int i = 0;
                if (header)
                {
                    string[] he = value[0].Split(delimiter);
                    foreach (string h in he)
                    {
                        data.Columns.Add(new DataColumn(h));
                    }
                    i = 1;
                }

                for(int j = 0 ;j < value.Count() - i; j++){
                    DataRow dr = data.NewRow();
                    data.Rows.Add(dr);
                    string[] col = value[j + i].Split(delimiter);
                    for (int k = 0; k < col.Count(); k++)
                    {
                        data.Rows[j][k] = (Convert.ToString(col[k]) == nullValue) ? null : col[k];
                    }
                    
                }
            }
            return rs;
        }

        /// <summary>
        ///    Hàm xóa tập tin:
        /// </summary>
        /// <param name="path">Đường dẫn lưu trữ file</param>        
        /// <param name="fileName">Tên file</param>        
        public static int ISDelete(string path, string fileName)
        {
            try
            {
                if (File.Exists(path + fileName))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers(); 
                    File.Delete(path + fileName);
                }
                else
                {
                    return -1;
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }


        #region CopyFile()

        /// <summary>
        ///    Hàm copy tập tin:
        /// </summary>
        /// <param name="oldPath">Đường dẫn lưu trữ file hiện tại</param>        
        /// <param name="newPath">Đường dẫn muốn chuyển file tới</param>     
        /// <param name="fileName">Tên file</param>     
        public static int ISCopy(string oldPath, string newPath, string fileName)
        {
            try
            {
                if (File.Exists(oldPath + fileName))
                {
                    File.Copy(oldPath + fileName, newPath + fileName);
                }
                else
                {
                    return -1;
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        ///    Hàm copy tập tin:
        /// </summary>
        /// <param name="oldPath">Đường dẫn lưu trữ file hiện tại</param>        
        /// <param name="newPath">Đường dẫn muốn chuyển file tới</param>     
        public static int ISCopy(string oldPath, string newPath)
        {
            try
            {
                if (File.Exists(oldPath))
                {
                    File.Copy(oldPath, newPath);
                }
                else
                {
                    return -1;
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public static int ISCopy(string oldPath, string newPath, out string error)
        {
            error = "";
            try
            {
                if (File.Exists(oldPath))
                {
                    File.Copy(oldPath, newPath);
                }
                else
                {
                    return -1;
                }
                return 1;
            }
            catch(Exception e)
            {
                error = e.Message;
                return 0;
            }
        }

        #endregion

        /// <summary>
        ///    Hàm di chuyển tập tin:
        /// </summary>
        /// <param name="oldPath">Đường dẫn lưu trữ file hiện tại</param>        
        /// <param name="newPath">Đường dẫn muốn chuyển file tới</param>     
        /// <param name="fileName">Tên file</param>     
        public static int ISMove(string oldPath, string newPath, string fileName)
        {
            try
            {
                if (File.Exists(oldPath + fileName))
                {
                    File.Move(oldPath + fileName, newPath + fileName);
                }
                else
                {
                    return -1;
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        ///    Hàm upload tập tin lên server trả về với kết quả:
        ///	   SaveFileResult{
        ///	        Success:true/false, 
        ///		    Errors:Danh sách thông báo lỗi, 
        ///		    Paths:Danh sách đường dẫn đã upload,  
        ///		    FileName:Tên tập tin có kèm đuôi mở rộng, 
        ///		    Extension:Đuôi mở rộng, 
        ///		    FileSize:Kích thước tập tin {
        ///			    Size: Kích thước, 
        ///			    Type: Đơn vị đo
        ///		    }
        ///	    }
        /// </summary>
        /// <param name="dataFile">Chuỗi base64</param>
        /// <param name="path">Đường dẫn lưu trữ file trên server</param>
        /// <param name="fileName">Tên tập tin</param>
        public static SaveFileResult ISSave(this string dataFile, string path, string fileName)
        {
            var result = new SaveFileResult { Success = false };
            if (string.IsNullOrEmpty(path))
            {
                result.Errors.Add("Path is empty");
                return result;
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (string.IsNullOrEmpty(fileName))
            {
                result.Errors.Add("File name is empty");
                return result;
            }

            if (string.IsNullOrEmpty(dataFile))
            {
                result.Errors.Add("Data is empty");
                return result;
            }

            //int indexBase = dataFile.IndexOf("base64,", StringComparison.Ordinal);
            //int s = indexBase + ("base64,").Length;
            //int n = dataFile.Length - s;
            //string data = dataFile.Substring(s, n);

            byte[] fileBytes = dataFile.ISBase64ToByte();
            result.Extension = fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal) + 1).ToLower();
            result.FileSizeOfByte = fileBytes.Length;
            result.FileSize = ToFileSize(fileBytes.Length);
            result.FileName = fileName;
            // If there are no errors save image
            if (result.Errors == null || !result.Errors.Any())
            {
                // Generate unique name for safety reasons
               
                result.Path = path;
                try
                {
                    using (FileStream file = new FileStream(path + fileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        file.Write(fileBytes, 0, fileBytes.Length);
                        file.Close();
                        file.Dispose();
                    }
                    result.Success = true;
                }
                catch { }
            }
            return result;
        }

        /// <summary>
        ///    Hàm upload tập tin lên server trả về với kết quả:
        ///	   SaveFileResult{
        ///	        Success:true/false, 
        ///		    Errors:Danh sách thông báo lỗi, 
        ///		    Paths:Danh sách đường dẫn đã upload,  
        ///		    FileName:Tên tập tin có kèm đuôi mở rộng, 
        ///		    Extension:Đuôi mở rộng, 
        ///		    FileSize:Kích thước tập tin {
        ///			    Size: Kích thước, 
        ///			    Type: Đơn vị đo
        ///		    }
        ///	    }
        /// </summary>
        /// <param name="dataFile">Chuỗi base64</param>
        /// <param name="path">Đường dẫn lưu trữ file trên server</param>
        /// <param name="fileName">Tên tập tin</param>
        public static SaveFileResult ISSave(this byte[] fileBytes, string path, string fileName)
        {
            var result = new SaveFileResult { Success = false };
            if (string.IsNullOrEmpty(path))
            {
                result.Errors.Add("Path is empty");
                return result;
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (string.IsNullOrEmpty(fileName))
            {
                result.Errors.Add("File name is empty");
                return result;
            }

            if (fileBytes == null)
            {
                result.Errors.Add("Data is empty");
                return result;
            }

            result.Extension = fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal) + 1).ToLower();
            result.FileSizeOfByte = fileBytes.Length;
            result.FileSize = ToFileSize(fileBytes.Length);
            result.FileName = fileName;
            // If there are no errors save image
            if (result.Errors == null || !result.Errors.Any())
            {
                // Generate unique name for safety reasons

                result.Path = path;
                try
                {
                    using (FileStream file = new FileStream(path + fileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        file.Write(fileBytes, 0, fileBytes.Length);
                        file.Close();
                        file.Dispose();
                    }
                    result.Success = true;
                }
                catch { }
            }
            return result;
        }

        /// <summary>
        ///    Hàm chuyển từ base64 thành HttpPostedFileBase:
        ///	   HttpPostedFileBase
        /// </summary>
        /// <param name="dataFile">chuỗi base64</param>
        public static byte[] ISBase64ToByte(this string dataFile)
        {

            if (string.IsNullOrEmpty(dataFile))
            {
                return null;
            }

            int indexBase = dataFile.IndexOf("base64,", StringComparison.Ordinal);
            if (indexBase > 0)
            {
                int s = indexBase + ("base64,").Length;
                int n = dataFile.Length - s;
                dataFile = dataFile.Substring(s, n);
            }

            return Convert.FromBase64String(dataFile);
        }

        /// <summary>
        ///    Hàm chuyển đổi kích thước tập tin trả về với kết quả:
        ///	   FileSizeResult{
        ///	        Size:Kích thước, 
        ///		    Type:Đơn vị đo
        ///	    }
        /// </summary>
        /// <param name="source">Kích thước nguồn[tính bằng byte]</param>
        public static FileSizeResult ToFileSize(int source)
        {
            return ToFileSize(Convert.ToInt64(source));
        }

        /// <summary>
        ///    Hàm chuyển đổi kích thước tập tin trả về với kết quả:
        ///	   FileSizeResult{
        ///	        Size:Kích thước, 
        ///		    Type:Đơn vị đo
        ///	    }
        /// </summary>
        /// <param name="source">Kích thước nguồn[tính bằng byte]</param>
        public static FileSizeResult ToFileSize(long source)
        {
            FileSizeResult size = new FileSizeResult();
            const int byteConversion = 1024;
            double bytes = Convert.ToDouble(source);

            if (bytes >= System.Math.Pow(byteConversion, 3)) //GB Range
            {
                size.Size = System.Math.Round(bytes / System.Math.Pow(byteConversion, 3), 2);
                size.Type = "GB";
            }
            else if (bytes >= System.Math.Pow(byteConversion, 2)) //MB Range
            {
                size.Size = System.Math.Round(bytes / System.Math.Pow(byteConversion, 2), 2);
                size.Type = "MB";
            }
            else if (bytes >= byteConversion) //KB Range
            {
                size.Size = System.Math.Round(bytes / byteConversion, 2);
                size.Type = "KB";
            }
            else //Bytes
            {
                size.Size = bytes;
                size.Type = "Bytes";
            }
            return size;
        }

        public static string GeneratedName()
        {
            System.Threading.Thread.Sleep(1);
            Random rnd = new Random();
            int w_rnd = rnd.Next(0, 100);
            rnd = new Random();
            int w_rnd2 = rnd.Next(0, 100);
            return DateTime.Now.ToString("yyyyMMddHHmmssFFFFFFF") + w_rnd.ToString() + w_rnd2.ToString();
        }
    }

    /// <summary>
    ///    kết qua upload
    /// </summary> 
    public class SaveFileResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public double FileSizeOfByte { get; set; }
        public FileSizeResult FileSize { get; set; }
    }

    /// <summary>
    ///    Kích thước tập tin
    /// </summary> 
    public class FileSizeResult
    {
        public double Size { get; set; }
        public string Type { get; set; }

    }
}