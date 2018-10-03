<script type="text/javascript"> 
var script_ntNotes = {
    ACEUserId_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('UserId','');
      var F_UserId = $get(sender._element.id);
      var F_UserId_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_UserId.value = p[0];
      F_UserId_Display.innerHTML = e.get_text();
    },
    ACEUserId_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('UserId','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEUserId_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_UserId: function(sender) {
      var Prefix = sender.id.replace('UserId','');
      this.validated_FK_Note_Notes_UserID_main = true;
      this.validate_FK_Note_Notes_UserID(sender,Prefix);
      },
    validate_FK_Note_Notes_UserID: function(o,Prefix) {
      var value = o.id;
      var UserId = $get(Prefix + 'UserId');
      if(UserId.value==''){
        if(this.validated_FK_Note_Notes_UserID_main){
          var o_d = $get(Prefix + 'UserId' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UserId.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_Note_Notes_UserID(value, this.validated_FK_Note_Notes_UserID);
      },
    validated_FK_Note_Notes_UserID_main: false,
    validated_FK_Note_Notes_UserID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_ntNotes.validated_FK_Note_Notes_UserID_main){
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
