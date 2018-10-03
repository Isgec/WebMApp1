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
    temp: function() {
    }
    }
</script>
