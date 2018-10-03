<script type="text/javascript"> 
var script_ctUserProject = {
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
    ACEProjectID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ProjectID','');
      var F_ProjectID = $get(sender._element.id);
      var F_ProjectID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ProjectID.value = p[0];
      F_ProjectID_Display.innerHTML = e.get_text();
    },
    ACEProjectID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ProjectID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEProjectID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_UserID: function(sender) {
      var Prefix = sender.id.replace('UserID','');
      this.validated_FK_CT_UserProject_UserID_main = true;
      this.validate_FK_CT_UserProject_UserID(sender,Prefix);
      },
    validate_ProjectID: function(sender) {
      var Prefix = sender.id.replace('ProjectID','');
      this.validated_FK_CT_UserProject_ProjectID_main = true;
      this.validate_FK_CT_UserProject_ProjectID(sender,Prefix);
      },
    validate_FK_CT_UserProject_UserID: function(o,Prefix) {
      var value = o.id;
      var UserID = $get(Prefix + 'UserID');
      if(UserID.value==''){
        if(this.validated_FK_CT_UserProject_UserID_main){
          var o_d = $get(Prefix + 'UserID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UserID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_CT_UserProject_UserID(value, this.validated_FK_CT_UserProject_UserID);
      },
    validated_FK_CT_UserProject_UserID_main: false,
    validated_FK_CT_UserProject_UserID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_ctUserProject.validated_FK_CT_UserProject_UserID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_CT_UserProject_ProjectID: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_CT_UserProject_ProjectID_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_CT_UserProject_ProjectID(value, this.validated_FK_CT_UserProject_ProjectID);
      },
    validated_FK_CT_UserProject_ProjectID_main: false,
    validated_FK_CT_UserProject_ProjectID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_ctUserProject.validated_FK_CT_UserProject_ProjectID_main){
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
