<script>
    var urlParams = new URLSearchParams(window.location.search);
    var drone_id = urlParams.get('drone_id');
    
    var urun = document.getElementById("Urun");
    urun.value = drone_id;
</script>