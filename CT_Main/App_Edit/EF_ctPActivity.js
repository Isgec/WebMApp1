<script type="text/javascript"> 
var script_ctPActivity = {
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
    ACEt_cact_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('t_cact','');
      var F_t_cact = $get(sender._element.id);
      var F_t_cact_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_t_cact.value = p[1];
      F_t_cact_Display.innerHTML = e.get_text();
    },
    ACEt_cact_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('t_cact','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
      var F_t_pcod = $get(Prefix + 't_pcod');
      sender._contextKey = F_t_pcod.value;
    },
    ACEt_cact_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_FK_ttpisg220200_t_cact: function(o,Prefix) {
      var value = o.id;
      var t_pcod = $get(Prefix + 't_pcod');
      if(t_pcod.value==''){
        if(this.validated_FK_ttpisg220200_t_cact_main){
          var o_d = $get(Prefix + 't_pcod' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + t_pcod.value ;
      var t_cact = $get(Prefix + 't_cact');
      if(t_cact.value==''){
        if(this.validated_FK_ttpisg220200_t_cact_main){
          var o_d = $get(Prefix + 't_cact' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + t_cact.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_ttpisg220200_t_cact(value, this.validated_FK_ttpisg220200_t_cact);
      },
    validated_FK_ttpisg220200_t_cact_main: false,
    validated_FK_ttpisg220200_t_cact: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_ctPActivity.validated_FK_ttpisg220200_t_cact_main){
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
