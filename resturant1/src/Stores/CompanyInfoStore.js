/* ---- Footer Store ---- */

const CompanyInfoStore = {
    state: {
        companyInfo : 
            {
              name: "Egon",
              type: "Resturant",
              yearEstablished: 1998,
              telefonNumber: "900 45 006" ,
              epost: "Egon.kundeservice@gmail.com",
              adress: "Storgata 1, 0150 Oslo"
            },
        
    },
    getCompanyInfo(){
        //insted of returning the data that is in the object CompanyInfoStore, i return whats in the LocalStorage.
        return JSON.parse(window.localStorage.getItem('info'));
    }
}

export default CompanyInfoStore;

/*
**** If localstorage is not defined, then make new localStorage. Else recall data ****
*/

let JSONinfo = CompanyInfoStore.state.companyInfo;
if(window.localStorage.getItem("info") === null){
    window.localStorage.setItem('info', JSON.stringify(JSONinfo));
} else {
    JSONinfo = JSON.parse(localStorage.getItem("info"));
}




