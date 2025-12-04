(function() {
   const h3 = document.getElementById('title');
   if ("index" == document.title) {
     h3.append("Home");
   }
   else {
     const a1 = document.createElement('a');
     a1.href = "index.html";
     a1.style = "color:royalblue";
     a1.append("Home");
     h3.appendChild(a1);
     h3.append(" :: " + document.title);
   }
})();


// Open external links in new tabs and open internal links in current tabs
var links    = document.getElementsByTagName("a");
var thisHref = window.location.hostname;

for(var i = 0; i < links.length; i++) {

   templink = links[i].href;
   a        = getLocation(templink);
 
   if (templink.includes(".pdf") || templink.includes(".jpg") || templink.includes(".png")) {
      links[i].target='_blank';
   }
   else if (a.hostname == thisHref) { // if the link is same with current page URL
      links[i].removeAttribute("target");
   }
   else {
      links[i].target='_blank'; // if the link is same with current page URL
   }
}

function getLocation(href) {

   var location      = document.createElement("a");
       location.href = href;

   if (location.host == "") {
      location.href = location.href;
   }
   return location;
};
