/*!
* SlidePaging v0.1
* Autor: Bernardo Fonseca Matias
* Date: 05/04/2011
* Dependencias: jquery
*/
// ***********************************************************************************************************
// Classe SlidePaging
// ***********************************************************************************************************
function SlidePaging() {
    // ***********************************************************************************************************
    // Propriedades
    // ***********************************************************************************************************
    this.url = null;
    this.htmlContainer = null;
    this.delegateDataReceived = null;
    this.delegateGetJsonSendData = null;
    this.stringSearchForValidationDataReceived = null;
    this.nextButton = null;
    this.previousButton = null;
    this.delegateSlideToNextPage = null;
    this.delegateSlideToPreviousPage = null;
    this.pageChangeLocked = false;

    // ***********************************************************************************************************
    // Internals
    // ***********************************************************************************************************
    var currentPage;
    var totalPages;
    var lastPageLoaded = false;
    var trySlideToNextPage = false;
    var loadingPage = false;

    // ***********************************************************************************************************
    // Métodos Públicos
    // ***********************************************************************************************************
    this.start = function (pCurrentPage, pTotalPages) {
        totalPages = pTotalPages;
        currentPage = pCurrentPage;

        registerEvents(this);
    }

    this.nextPage = function () {
        if (!this.pageChangeLocked) {
            if (currentPage < totalPages) {
                if (!lastPageLoaded && currentPage == (totalPages - 1)) {
                    getAjaxPage(this);
                }
                currentPage++;
                this.delegateSlideToNextPage();
            }
            else if (loadingPage) {
                trySlideToNextPage = true;
            }
        }
    }

    this.previousPage = function () {
        if (!this.pageChangeLocked) {
            if (currentPage > 1) {
                currentPage--;
                this.delegateSlideToPreviousPage();
            }
            if (trySlideToNextPage) {
                trySlideToNextPage = false;
            }
        }
    }

    this.lockPageChange = function () {
        this.pageChangeLocked = true;
    }

    this.unlockPageChange = function () {
        this.pageChangeLocked = false;
    }

    // ***********************************************************************************************************
    // Métodos Privados
    // ***********************************************************************************************************
    function getAjaxPage(mySelf) {
        var jsonSendData = null;

        loadingPage = true;

        if (mySelf.delegateGetJsonSendData) {
            jsonSendData = mySelf.delegateGetJsonSendData();
        }
        if (jsonSendData == null) {
            jsonSendData = "{}";
        }
        $.ajax({
            type: "POST",
            url: mySelf.url,
            data: "{ parameters: " + jsonSendData + ", page: " + (totalPages + 1) + " }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                writePageInContainer(data, mySelf);
                if (mySelf.delegateDataReceived) {
                    mySelf.delegateDataReceived();
                }
            }
        });
    }

    function writePageInContainer(data, mySelf) {
        if (data.d.indexOf(mySelf.stringSearchForValidationDataReceived) >= 0) {
            mySelf.htmlContainer.innerHTML += data.d;
            totalPages++;
            loadingPage = false;
            if (trySlideToNextPage) {
                mySelf.nextPage();
            }
        }
        else {
            lastPageLoaded = true;
            loadingPage = false;
        }
        trySlideToNextPage = false;
    }

    function registerEvents(mySelf) {
        if (mySelf.nextButton) {
            mySelf.nextButton.click(function () {
                mySelf.nextPage();
                return false;
            });
        }
        if (mySelf.previousButton) {
            mySelf.previousButton.click(function () {
                mySelf.previousPage();
                return false;
            });
        }
    }

}
// ***********************************************************************************************************
