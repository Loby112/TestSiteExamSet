const baseUrl = "https://localhost:44309/api/TestSites"

Vue.createApp({
    data(){
        return{
            testSites: [],
            idToGetBy: -1,
            singleTestSite: null,
            deleteId: 0,
            newTestSite: {"id": 0,"name": "","waitingTime":0},
            addMessage: "",
            updateTestSite: {"id": 0,"name": "","waitingTime":0},
            filterString: ""
        }
    },
    created(){
        this.getAllTestSites("")
    },
    methods: {
        async helperGetAndShow(url){
            try{
                const response = await axios.get(url)
                this.testSites = await response.data
            } catch (ex){
                alert(ex.message)
            }
        },

        getAllTestSites(filter){
            let url = baseUrl
            if(filter == "name"){
                url = url + '?filterString=name'
            }
            else if(filter == "time"){
                url = url + '?filterString=time'
            }
            else {
                url = url + '?filterString=' + filter
            }
            this.helperGetAndShow(url)
        }
    }

}).mount('#app')