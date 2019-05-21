<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
	<link id="favicon" rel="icon" href="~/Content/favicon.png"/>
    <title>@ViewBag.Title - My ASP.NET Application</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/modernizr-2.6.2.js"></script>
    <link rel="manifest" href="~/Scripts/manifest.json" />
	<script src="~/service-worker.js"></script>
    @*<script src="~/Scripts/main.js"></script>*@
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Web Notification", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav"></ul>
            </div>
        </div>
    </div>

    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
	<script type="text/javascript">
	
		function changeFavicon(ShowNotify) {
			const title = 'Simple Title';
			
			if (ShowNotify) {
				document.getElementById('favicon').href = 'Content/favicon-red.png';				
				const options = {
					body: 'This is Unread Notification )'
				};
				navigator.serviceWorker.ready.then(function (registration) {
					registration.showNotification(title, options);
				});
			}
			else {
				document.getElementById('favicon').href = 'Content/favicon.png';
				const options = {
					body: 'This is Read Notification)'
				};
				navigator.serviceWorker.ready.then(function (registration) {
					registration.showNotification(title, options);
				});
			}
		}
		
	</script>
    <script>
        if ('serviceWorker' in navigator) {
            navigator.serviceWorker.register('./service-worker.js').then(function (registration) {
                if ('pushManager' in registration) {
                    Notification.requestPermission(function (result) {
                        if (result === 'granted') {
                            console.log('granted');
                            //navigator.serviceWorker.ready.then(function (registration) {
                            //    registration.showNotification('Vibration Sample', {
                            //        body: 'Buzz! Buzz!',
                            //        icon: '../Scripts/assets/smiley-192x192.png',
                            //        vibrate: [200, 100, 200, 100, 200, 100, 200],
                            //        tag: 'vibration-sample'
                            //    });
                            //});
                        }
                        else {
                            console.log('not granted');
                        }
                        console.log('Service Worker Registered');
                    });
                } else {
                    console.log("pushManager  not allow")
                }
            });
        } else {
            console.log("not support")
        }
        // Setup Push notifications

        function showNotification() {
            Notification.requestPermission(function (result) {
                if (result === 'granted') {
                    navigator.serviceWorker.ready.then(function (registration) {
                        registration.showNotification('Vibration Sample', {
                            body: 'Buzz! Buzz!',
                            icon: '../images/touch/chrome-touch-icon-192x192.png',
                            vibrate: [200, 100, 200, 100, 200, 100, 200],
                            tag: 'vibration-sample'
                        });
                    });
                }
            });
        }
    </script>
</body>
</html>
