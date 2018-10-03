<script type="text/javascript"> 
var script_mappUserApps = {
    ACEAppID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('AppID','');
      var F_AppID = $get(sender._element.id);
      var F_AppID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_AppID.value = p[0];
      F_AppID_Display.innerHTML = e.get_text();
    },
    ACEAppID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('AppID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEAppID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEUserID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('UserID','');
      var F_UserID = $get(sender._element.id);
      var F_UserID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_UserID.value = p[0];
      F_UserID_Display.innerHTML = e.get_text();
    },
    ACEUserID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('UserID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEUserID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_AppID: function(sender) {
      var Prefix = sender.id.replace('AppID','');
      this.validated_FK_MAPP_UserApps_ApplID_main = true;
      this.validate_FK_MAPP_UserApps_ApplID(sender,Prefix);
      },
    validate_UserID: function(sender) {
      var Prefix = sender.id.replace('UserID','');
      this.validated_FK_MAPP_UserApps_UserID_main = true;
      this.validate_FK_MAPP_UserApps_UserID(sender,Prefix);
      },
    validate_FK_MAPP_UserApps_UserID: function(o,Prefix) {
      var value = o.id;
      var UserID = $get(Prefix + 'UserID');
      if(UserID.value==''){
        if(this.validated_FK_MAPP_UserApps_UserID_main){
          var o_d = $get(Prefix + 'UserID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UserID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_MAPP_UserApps_UserID(value, this.validated_FK_MAPP_UserApps_UserID);
      },
    validated_FK_MAPP_UserApps_UserID_main: false,
    validated_FK_MAPP_UserApps_UserID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_mappUserApps.validated_FK_MAPP_UserApps_UserID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_MAPP_UserApps_ApplID: function(o,Prefix) {
      var value = o.id;
      var AppID = $get(Prefix + 'AppID');
      if(AppID.value==''){
        if(this.validated_FK_MAPP_UserApps_ApplID_main){
          var o_d = $get(Prefix + 'AppID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + AppID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_MAPP_UserApps_ApplID(value, this.validated_FK_MAPP_UserApps_ApplID);
      },
    validated_FK_MAPP_UserApps_ApplID_main: false,
    validated_FK_MAPP_UserApps_ApplID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_mappUserApps.validated_FK_MAPP_UserApps_ApplID_main){
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
