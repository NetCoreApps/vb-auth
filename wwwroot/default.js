var ALIASES = {
};
var global = window;
window.exports = {};
window.require = function (name) {
    return ALIASES[name] || exports[name] || window[name] || exports;
};
Object.assign(window, window["@servicestack/client"]); //import into global namespace

var client = new JsonServiceClient();

function initAuthPage(opt) {
    client.get(new Authenticate())
        .then(function (r) {
            document.getElementById('profile').innerHTML =
                '<div id="session">'
                + (r.profileUrl ? '<img style="height:24px" class="mr-1" src="' + r.profileUrl + '">' : '') + r.displayName
                + '</div>'
                + '<a class="mr-1" href="/"><svg xmlns="http://www.w3.org/2000/svg" height="24" viewBox="0 0 24 24" width="24"><path d="M0 0h24v24H0z" fill="none"/><path fill="#556080" d="M10 20v-6h4v6h5v-8h3L12 3 2 12h3v8z"/></svg></a>' 
                + '<a class="btn btn-outline-secondary btn-sm mt-1" href="/auth/logout">Sign Out</a>';
            if (opt.hasAuth)
                opt.hasAuth(r);
        })
        .catch(function (e) {
            if (opt.noAuth)
                opt.noAuth();
            else if (opt.redirect)
                location.href = '/login.html?redirect=' + opt.redirect;
        });
}
