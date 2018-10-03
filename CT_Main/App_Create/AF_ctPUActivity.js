<script type="text/javascript"> 
var script_ctPUActivity = {
    ACEt_cprj_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('t_cprj','');
      var F_t_cprj = $get(sender._element.id);
      var F_t_cprj_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_t_cprj.value = p[0];
      F_t_cprj_Display.innerHTML = e.get_text();
    },
    ACEt_cprj_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('t_cprj','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEt_cprj_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEt_atid_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('t_atid','');
      var F_t_atid = $get(sender._element.id);
      var F_t_atid_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_t_atid.value = p[1];
      F_t_atid_Display.innerHTML = e.get_text();
    },
    ACEt_atid_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('t_atid','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEt_atid_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_t_atid: function(sender) {
      var Prefix = sender.id.replace('t_atid','');
      this.validated_FK_ttpisg183200_t_atid_main = true;
      this.validate_FK_ttpisg183200_t_atid(sender,Prefix);
      },
    validate_t_cprj: function(sender) {
      var Prefix = sender.id.replace('t_cprj','');
      this.validated_FK_ttpisg183200_t_cprj_main = true;
      this.validate_FK_ttpisg183200_t_cprj(sender,Prefix);
      },
    validate_FK_ttpisg183200_t_cprj: function(o,Prefix) {
      var value = o.id;
      var t_cprj = $get(Prefix + 't_cprj');
      if(t_cprj.value==''){
        if(this.validated_FK_ttpisg183200_t_cprj_main){
          var o_d = $get(Prefix + 't_cprj' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + t_cprj.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_ttpisg183200_t_cprj(value, this.validated_FK_ttpisg183200_t_cprj);
      },
    validated_FK_ttpisg183200_t_cprj_main: false,
    validated_FK_ttpisg183200_t_cprj: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_ctPUActivity.validated_FK_ttpisg183200_t_cprj_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_ttpisg183200_t_atid: function(o,Prefix) {
      var value = o.id;
      var t_cprj = $get(Prefix + 't_cprj');
      if(t_cprj.value==''){
        if(this.validated_FK_ttpisg183200_t_atid_main){
          var o_d = $get(Prefix + 't_cprj' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + t_cprj.value ;
      var t_atid = $get(Prefix + 't_atid');
      if(t_atid.value==''){
        if(this.validated_FK_ttpisg183200_t_atid_main){
          var o_d = $get(Prefix + 't_atid' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + t_atid.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_ttpisg183200_t_atid(value, this.validated_FK_ttpisg183200_t_atid);
      },
    validated_FK_ttpisg183200_t_atid_main: false,
    validated_FK_ttpisg183200_t_atid: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_ctPUActivity.validated_FK_ttpisg183200_t_atid_main){
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
