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
    temp: function() {
    }
    }
</script>
