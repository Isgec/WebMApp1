<script type="text/javascript"> 
var script_mappApplications = {
    ACEAppIconID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('AppIconID','');
      var F_AppIconID = $get(sender._element.id);
      var F_AppIconID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_AppIconID.value = p[0];
      F_AppIconID_Display.innerHTML = e.get_text();
    },
    ACEAppIconID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('AppIconID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEAppIconID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_AppIconID: function(sender) {
      var Prefix = sender.id.replace('AppIconID','');
      this.validated_FK_MAPP_Applications_ApplIconID_main = true;
      this.validate_FK_MAPP_Applications_ApplIconID(sender,Prefix);
      },
    validate_FK_MAPP_Applications_ApplIconID: function(o,Prefix) {
      var value = o.id;
      var AppIconID = $get(Prefix + 'AppIconID');
      if(AppIconID.value==''){
        if(this.validated_FK_MAPP_Applications_ApplIconID_main){
          var o_d = $get(Prefix + 'AppIconID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + AppIconID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_MAPP_Applications_ApplIconID(value, this.validated_FK_MAPP_Applications_ApplIconID);
      },
    validated_FK_MAPP_Applications_ApplIconID_main: false,
    validated_FK_MAPP_Applications_ApplIconID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_mappApplications.validated_FK_MAPP_Applications_ApplIconID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
