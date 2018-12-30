(function (cibertec) {

    cibertec.video = {

        play: function (videoId) {
            document.getElementById(videoId).play();
        },
        pause: function (videoId) {
            document.getElementById(videoId).pause();
        },

        stop: function (videoId) {
            var video = document.getElementById(videoId);
            video.currentTime = 0;
            video.pause();
        }

    }

})(window.cibertec = window.cibertec || {});

