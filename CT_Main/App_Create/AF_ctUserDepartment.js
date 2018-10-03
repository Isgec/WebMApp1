<script type="text/javascript"> 
var script_ctUserDepartment = {
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
    ACEDepartmentID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('DepartmentID','');
      var F_DepartmentID = $get(sender._element.id);
      var F_DepartmentID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_DepartmentID.value = p[0];
      F_DepartmentID_Display.innerHTML = e.get_text();
    },
    ACEDepartmentID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('DepartmentID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEDepartmentID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_UserID: function(sender) {
      var Prefix = sender.id.replace('UserID','');
      this.validated_FK_CT_UserDepartment_UserID_main = true;
      this.validate_FK_CT_UserDepartment_UserID(sender,Prefix);
      },
    validate_DepartmentID: function(sender) {
      var Prefix = sender.id.replace('DepartmentID','');
      this.validated_FK_CT_UserDepartment_DepartmentID_main = true;
      this.validate_FK_CT_UserDepartment_DepartmentID(sender,Prefix);
      },
    validate_FK_CT_UserDepartment_UserID: function(o,Prefix) {
      var value = o.id;
      var UserID = $get(Prefix + 'UserID');
      if(UserID.value==''){
        if(this.validated_FK_CT_UserDepartment_UserID_main){
          var o_d = $get(Prefix + 'UserID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UserID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_CT_UserDepartment_UserID(value, this.validated_FK_CT_UserDepartment_UserID);
      },
    validated_FK_CT_UserDepartment_UserID_main: false,
    validated_FK_CT_UserDepartment_UserID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_ctUserDepartment.validated_FK_CT_UserDepartment_UserID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_CT_UserDepartment_DepartmentID: function(o,Prefix) {
      var value = o.id;
      var DepartmentID = $get(Prefix + 'DepartmentID');
      if(DepartmentID.value==''){
        if(this.validated_FK_CT_UserDepartment_DepartmentID_main){
          var o_d = $get(Prefix + 'DepartmentID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + DepartmentID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_CT_UserDepartment_DepartmentID(value, this.validated_FK_CT_UserDepartment_DepartmentID);
      },
    validated_FK_CT_UserDepartment_DepartmentID_main: false,
    validated_FK_CT_UserDepartment_DepartmentID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_ctUserDepartment.validated_FK_CT_UserDepartment_DepartmentID_main){
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
