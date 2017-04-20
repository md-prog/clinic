//nevermind this
import Vue from 'vue';

Vue.mixin({
    methods: {
        lookup: function(type, value, data){
            switch(type){
                case "lab":
                case "client":
                default:
                    var retVal = data.find(function(c) {return c.id == value;});
                    if(typeof(retVal)!='undefined')
                        return retVal;
                    else
                        return new {
                            id: 0,
                            name: 'Unknown'
                        };
                    break;
            }
        },
    }
});