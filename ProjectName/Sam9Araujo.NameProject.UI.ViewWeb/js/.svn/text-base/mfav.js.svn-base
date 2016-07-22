//
// Meus Favoritos
//
var cookieFavDefaultName = "ckMeFav";
var cookieFav;
var divFav;

function mainFavItens() {
    if (document.getElementById("divFavItensAmbiente")) {
        divFav = document.getElementById("divFavItensAmbiente");
        cookieFav = cookieFavDefaultName + "Ambiente";
        populateFavItens(getFavoritos());
    } else if (document.getElementById("divFavItensProduto")) {
        //divFav = document.getElementById("divFavItensProduto");
        //cookieFav = cookieFavDefaultName + "Produto";
    }
    //populateFavItens(getFavoritos());
}

function populateFavItens(fav) {
    if (divFav) {
        if (fav.favoritos.length > 0) {
            divFav.innerHTML = "";
            for (i = 0; i < fav.favoritos.length; i++) {
                divFav.innerHTML += getHtmlItem(fav.favoritos[i]);
            }
        }
        else {
            divFav.innerHTML = "<br />";
        }
    }
}

function setFavItem(nome, href) {
    var existe = false;
    var fav = getFavoritos();

    for (i = 0; i < fav.favoritos.length; i++)
        if (fav.favoritos[i].nome == nome)
            existe = true;

    if (!existe)
    {
        fav.favoritos.push(getItem(nome, href));
        setFavoritos(fav);
        populateFavItens(fav);
    }
}

function removeFavItem(nome) {
    var existe = false;
    var fav = getFavoritos();

    for (i = 0; i < fav.favoritos.length; i++) {
        if (fav.favoritos[i].nome == nome) {
            fav.favoritos.splice(i, 1);
            setFavoritos(fav);
            populateFavItens(fav);
            return;
        }
    }
}

function getFavoritos() {
    var jsonFav;
    var sCookie = getCookie(cookieFav);

    if (sCookie != null)
        jsonFav = sCookie;
    else
        jsonFav = "{\"favoritos\": [] }";

    return JSON.parse(jsonFav);
}

function setFavoritos(fav) {
    var jsonFav = JSON.stringify(fav);

    setCookie(cookieFav, jsonFav, 365);
}

function getItem(nome, href) {
    return JSON.parse(getJsonItem(nome, href));
}

function getJsonItem(nome, href) {
    return "{\"nome\": \"" + nome + "\", \"href\": \"" + href + "\"}";
}

function getHtmlItem(fav) {
    return "<p><a href=\"" + fav.href + "\">" + fav.nome + "</a><span onclick=\"removeFavItem('" + fav.nome + "')\">[x]</span></p>";
}

function addEvent(evt, fnc) {
    if (typeof window.addEventListener != "undefined")
        window.addEventListener(evt, fnc, false);
    else if (typeof window.attachEvent != "undefined")
        window.attachEvent("on" + evt, fnc);
}


addEvent("load", mainFavItens);
