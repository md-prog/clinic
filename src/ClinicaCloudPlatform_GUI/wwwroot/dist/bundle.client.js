webpackJsonp([0],{

/***/ 272:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _app = __webpack_require__(296);

//import 'bootstrap'
//require('./assets/style/app.css')

//store.replaceState(__INITIAL_STATE__);

_app.app.$mount('.my-app');

/***/ }),

/***/ 296:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.store = exports.app = undefined;

var _extends = Object.assign || function (target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i]; for (var key in source) { if (Object.prototype.hasOwnProperty.call(source, key)) { target[key] = source[key]; } } } return target; };

__webpack_require__(343);

var _vue = __webpack_require__(51);

var _vue2 = _interopRequireDefault(_vue);

var _App = __webpack_require__(632);

var _App2 = _interopRequireDefault(_App);

var _index = __webpack_require__(320);

var _index2 = _interopRequireDefault(_index);

var _vueRouter = __webpack_require__(683);

var _vueRouter2 = _interopRequireDefault(_vueRouter);

var _vue2Filters = __webpack_require__(695);

var _vue2Filters2 = _interopRequireDefault(_vue2Filters);

var _routes = __webpack_require__(319);

var _routes2 = _interopRequireDefault(_routes);

var _paceProgress = __webpack_require__(601);

var _paceProgress2 = _interopRequireDefault(_paceProgress);

var _chart = __webpack_require__(345);

var _chart2 = _interopRequireDefault(_chart);

var _filters = __webpack_require__(316);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

__webpack_require__(584);

__webpack_require__(297);

__webpack_require__(586);

_vue2.default.filter('count', _filters.count);
_vue2.default.filter('domain', _filters.domain);
_vue2.default.filter('prettyDate', _filters.prettyDate);
_vue2.default.filter('MMDDYYYY', _filters.MMDDYYYY);
_vue2.default.filter('MMDDYYYYhhmm', _filters.MMDDYYYYhhmm);
_vue2.default.filter('localeDate', _filters.localeDate);
_vue2.default.filter('pluralize', _filters.pluralize);
_vue2.default.filter('truncate', _filters.truncate);
_vue2.default.filter('localeDateOrTimeToday', _filters.localeDateOrTimeToday);

// Routing logic

_vue2.default.use(_vueRouter2.default);

var router = new _vueRouter2.default({
    routes: _routes2.default,
    mode: 'history',
    scrollBehavior: function scrollBehavior(to, from, savedPosition) {
        return savedPosition || { x: 0, y: 0 };
    },
    linkActiveClass: ''
});

_vue2.default.use(_vue2Filters2.default);

//router.afterEach(route => {
//    document.title = route.meta.title;
//});

var app = new _vue2.default(_extends({
    store: _index2.default,
    router: router
}, _App2.default));

exports.app = app;
exports.store = _index2.default;

/***/ }),

/***/ 297:
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function($) {

/*****
* CONFIGURATION
*/
//Main navigation
$.navigation = $('nav > ul.nav');

$.panelIconOpened = 'icon-arrow-up';
$.panelIconClosed = 'icon-arrow-down';

//Default colours
$.brandPrimary = '#20a8d8';
$.brandSuccess = '#4dbd74';
$.brandInfo = '#63c2de';
$.brandWarning = '#f8cb00';
$.brandDanger = '#f86c6b';

$.grayDark = '#2a2c36';
$.gray = '#55595c';
$.grayLight = '#818a91';
$.grayLighter = '#d1d4d7';
$.grayLightest = '#f8f9fa';

'use strict';

/****
* MAIN NAVIGATION
*/

$(document).ready(function ($) {

  // Add class .active to current link
  $.navigation.find('a').each(function () {

    var cUrl = String(window.location).split('?')[0];

    if (cUrl.substr(cUrl.length - 1) == '#') {
      cUrl = cUrl.slice(0, -1);
    }

    if ($($(this))[0].href == cUrl) {
      $(this).addClass('active');

      $(this).parents('ul').add(this).each(function () {
        $(this).parent().addClass('open');
      });
    }
  });

  // Dropdown Menu
  $.navigation.on('click', 'a', function (e) {

    if ($.ajaxLoad) {
      e.preventDefault();
    }

    if ($(this).hasClass('nav-dropdown-toggle')) {
      $(this).parent().toggleClass('open');
      resizeBroadcast();
    }
  });

  function resizeBroadcast() {

    var timesRun = 0;
    var interval = setInterval(function () {
      timesRun += 1;
      if (timesRun === 5) {
        clearInterval(interval);
      }
      window.dispatchEvent(new Event('resize'));
    }, 62.5);
  }

  /* ---------- Main Menu Open/Close, Min/Full ---------- */
  $('.navbar-toggler').click(function () {

    if ($(this).hasClass('sidebar-toggler')) {
      $('body').toggleClass('sidebar-hidden');
      resizeBroadcast();
    }

    if ($(this).hasClass('aside-menu-toggler')) {
      $('body').toggleClass('aside-menu-hidden');
      resizeBroadcast();
    }

    if ($(this).hasClass('mobile-sidebar-toggler')) {
      $('body').toggleClass('sidebar-mobile-show');
      resizeBroadcast();
    }
  });

  $('.sidebar-close').click(function () {
    $('body').toggleClass('sidebar-opened').parent().toggleClass('sidebar-opened');
  });

  /* ---------- Disable moving to top ---------- */
  $('a[href="#"][data-top!=true]').click(function (e) {
    e.preventDefault();
  });
});

/****
* CARDS ACTIONS
*/

$(document).on('click', '.card-actions a', function (e) {
  e.preventDefault();

  if ($(this).hasClass('btn-close')) {
    $(this).parent().parent().parent().fadeOut();
  } else if ($(this).hasClass('btn-minimize')) {
    var $target = $(this).parent().parent().next('.card-block');
    if (!$(this).hasClass('collapsed')) {
      $('i', $(this)).removeClass($.panelIconOpened).addClass($.panelIconClosed);
    } else {
      $('i', $(this)).removeClass($.panelIconClosed).addClass($.panelIconOpened);
    }
  } else if ($(this).hasClass('btn-setting')) {
    $('#myModal').modal('show');
  }
});

function capitalizeFirstLetter(string) {
  return string.charAt(0).toUpperCase() + string.slice(1);
}

function init(url) {

  /* ---------- Tooltip ---------- */
  $('[rel="tooltip"],[data-rel="tooltip"]').tooltip({ "placement": "bottom", delay: { show: 400, hide: 200 } });

  /* ---------- Popover ---------- */
  $('[rel="popover"],[data-rel="popover"],[data-toggle="popover"]').popover();
}
/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(8)))

/***/ }),

/***/ 298:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


module.exports = function (set, fn) {
  return new Set(Array.from(set).filter(fn));
};

/***/ }),

/***/ 299:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


module.exports = {
    accessionState: {
        loaded: false,
        isNew: false,
        isLoadingClientsAsync: false,
        accession: {},
        accessionTemplate: {
            "id": 0,
            "guid": "00000000-0000-0000-0000-000000000000",
            "clientId": 0,
            "facilityId": 0,
            "patientId": 0,
            "mrn": '',
            "orderingLabId": 0,
            "specimens": [],
            "cases": []
        },
        clients: [{
            "id": 0,
            "name": '',
            "facilities": [{
                "id": 0,
                "name": ''
            }]
        }],
        labs: [{
            "id": 0,
            "name": ''
        }]
    }
};

/***/ }),

/***/ 300:
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function($) {

var _axios = __webpack_require__(40);

var _axios2 = _interopRequireDefault(_axios);

var _vueMultiselect = __webpack_require__(79);

var _vueMultiselect2 = _interopRequireDefault(_vueMultiselect);

var _AccessioningVueData = __webpack_require__(299);

var _AccessioningVueData2 = _interopRequireDefault(_AccessioningVueData);

var _setFilter = __webpack_require__(298);

var _setFilter2 = _interopRequireDefault(_setFilter);

var _objectMerge = __webpack_require__(617);

var _objectMerge2 = _interopRequireDefault(_objectMerge);

var _debounce = __webpack_require__(152);

var _debounce2 = _interopRequireDefault(_debounce);

var _Patient = __webpack_require__(636);

var _Patient2 = _interopRequireDefault(_Patient);

var _Specimens = __webpack_require__(637);

var _Specimens2 = _interopRequireDefault(_Specimens);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

//var loadInProgress = false;

//import { mapGetters, mapActions} from 'vuex';
var uuidV1 = __webpack_require__(78);

module.exports = {
    name: "Accessioning",

    components: {
        Multiselect: _vueMultiselect2.default,
        Patient: _Patient2.default,
        Specimens: _Specimens2.default
    },

    props: {
        user: Object,
        organization: Object
    },

    data: function data() {
        return { accessionState: _AccessioningVueData2.default.accessionState };
    },

    ///vue computed properties

    computed: {
        //loaded: function() { return this.accessionState.loaded;},
        //isNew: function() { return this.accessionState.isNew;},
        client: {
            get: function get() {
                var cId = this.accessionState.accession.clientId;
                return this.accessionState.clients.find(function (c) {
                    return c.id == cId;
                });
            },
            set: function set(value) {
                this.$set(this.accessionState.accession, 'clientId', value.id);
                //facility depends on client, choose the first one
                this.$set(this.accessionState.accession, 'facilityId', value.facilities[0].id);
            }
        },
        facility: {
            get: function get() {
                var fId = this.accessionState.accession.facilityId;
                return this.facilities.find(function (f) {
                    return f.id == fId;
                });
            },
            set: function set(value) {
                this.$set(this.accessionState.accession, 'facilityId', value.id);
            }
        },
        lab: {
            get: function get() {
                var lId = this.accessionState.accession.orderingLabId;
                return this.accessionState.labs.find(function (l) {
                    return l.id == lId;
                });
            },
            set: function set(value) {
                this.$set(this.accessionState.accession, 'orderingLabId', value.id);
            }
        },
        patient: {
            get: function get() {
                var pId = this.accessionState.accession.patientId;
                return this.accessionState.patients.find(function (p) {
                    return p.id == pId;
                });
            }
        },

        facilities: function facilities() {
            var facilities = [{ id: 0, name: "" }];
            var cId = this.accessionState.accession.clientId;
            var cli = this.accessionState.clients.find(function (c) {
                return c.id == cId;
            });
            if (typeof cli != 'undefined') facilities = cli.facilities;
            return facilities;
        }
    },

    //end computed

    //vue watchers

    watch: {
        //loaded: function() {
        //    if (this.loaded)
        //    {
        //        var vm = this;
        //        vm.$nextTick(function() { this.finalizeView(); });
        //    }
        //},
        '$route': function $route() {
            var vm = this;
            //if(vm.loaded) //don't do this if still loading... not sure why needed
            vm.initView();
        }
    },

    //end watchers

    //vue lifecycle events

    created: function created() {
        this.initView();
    },

    mounted: function mounted() {
        //setupFormOverlays();
    },

    //end lifecycle events

    //vue methods

    methods: {

        initView: function initView() {
            var accId = 0;
            var vm = this;

            vm.$set(vm.accessionState, 'loaded', false);
            vm.$set(vm.accessionState, 'currentAction', 'Loading');

            if (vm.$route.params.id == null) vm.newAccession();else {
                vm.$set(vm.accessionState, 'isNew', false);
                accId = this.$route.params.id;
            }

            vm.$nextTick(function () {
                $("#loadingModal").modal("show");
            });

            if (vm.accessionState.isNew || vm.accessionState.accession.id != accId) {
                vm.loadAll(this.$route.params.id, vm.$route.params.orgNameKey);
            } else {
                vm.$set(vm.accessionState, 'loaded', true);
                vm.$nextTick(function () {
                    vm.finalizeView();
                });
            }
        },

        finalizeView: function finalizeView() {
            //see watcher on loaded property

            $("#loadingModal").modal("hide");

            $('.dateOnlyPicker').daterangepicker({
                "singleDatePicker": true,
                "timePicker": false,
                locale: {
                    format: 'M/D/YYYY'
                }
            });

            $('.dateTimePicker').daterangepicker({
                "singleDatePicker": true,
                "timePicker": true
            });
        },

        afterLoad: function afterLoad(vm) {
            if (!vm.accessionState.isNew) vm.postSave(vm);
            vm.$set(vm.accessionState, 'loaded', true);
            vm.$nextTick(function () {
                vm.finalizeView();
            });
        },

        postSave: function postSave(vm) {
            vm.setHistoryItems(vm);
        },

        setHistoryItems: function setHistoryItems(vm) {
            var accId = vm.accessionState.accession.id;
            var accTimestamp = vm.accessionState.accession.createdDate;
            var subject = vm.patient.lastName;
            var specimens = vm.accessionState.accession.specimens.map(function (s) {
                return s.type.type;
            });
            var countedSpecimens = [];

            specimens.forEach(function (s) {
                typeof countedSpecimens.find(function (c) {
                    return c.string === s;
                }) === 'undefined' ? countedSpecimens.push({ string: s, count: 1 }) : countedSpecimens.find(function (c) {
                    return c.string === s;
                }).count++;
            });
            specimens = countedSpecimens.map(function (c) {
                return c.count + ' ' + vm.$options.filters.pluralize(c.count, c.string);
            });

            vm.$emit('viewEditItem', vm.$route.meta.title, accId, 'Accession # ' + accId, subject, specimens.join(', '), accTimestamp);
        },

        //todo validation

        validateSave: function validateSave() {
            return true;
        },

        //todo printing

        printAccession: function printAccession() {},

        printLabels: function printLabels() {},

        //component event handlers

        patient_changed: function patient_changed(patientId, doReload) {
            this.$set(this.accessionState.accession, 'patientId', patientId);
            if (doReload) this.loadPatients(this.organization);
        },

        specimens_changed: function specimens_changed(specimens) {
            this.$set(this.accessionState.accession, 'specimens', specimens);
        },

        //general

        dateFormat: function dateFormat(date) {
            return this.$options.filters.prettyDate(date);
        },

        //data

        getAccessionOrNew: function getAccessionOrNew(id, orgNameKey) {
            if (this.accessionState.isNew) return { "data": { "accession": this.accessionState.accession } }; //use the default empty template
            else return _axios2.default.get('/api/Accessioning/' + id + '/' + orgNameKey);
        },

        loadAll: function loadAll(id, orgNameKey) {
            var vm = this;
            _axios2.default.all([vm.getAccessionOrNew(id, orgNameKey), _axios2.default.get('/api/Client/' + orgNameKey), _axios2.default.get('/api/Patient/' + orgNameKey), _axios2.default.get('/api/Lab/' + orgNameKey)]).then(_axios2.default.spread(function (accResponse, clientResponse, patientResponse, labResponse) {
                vm.$set(vm.accessionState, 'accession', accResponse.data.accession);
                vm.$set(vm.accessionState, 'clients', clientResponse.data);
                vm.$set(vm.accessionState, 'patients', patientResponse.data);
                vm.$set(vm.accessionState, 'labs', labResponse.data);
                vm.afterLoad(vm);
            })).catch(function (err) {
                console.log(err);
            });
        },

        loadPatients: function loadPatients(orgNameKey) {
            var vm = this;
            _axios2.default.get('/api/Patient/' + orgNameKey).then(function (response) {
                vm.$set(vm.accessionState, 'patients', response.data);
            }).catch(function (err) {
                console.log(err);
            });
        },

        saveAccession: function saveAccession() {
            var _this = this;

            var vm = this;

            vm.$set(vm.accessionState, 'currentAction', 'Saving');

            vm.$set(vm.accessionState, 'loaded', false);
            vm.$nextTick(function () {
                $("#loadingModal").modal("show");
            });

            _axios2.default.post('/api/accessioning', {
                accession: vm.accessionState.accession,
                orgCustomData: vm.organization.customData,
                userFullName: vm.user.fullName,
                userHref: vm.user.href }).then(function (response) {
                vm.$set(vm.accessionState, 'loaded', true);
                vm.$set(_this.accessionState, 'isNew', false);
                _this.postSave(vm);
            });
        },

        newAccession: function newAccession() {
            var vm = this;
            vm.$set(vm.accessionState, 'currentAction', 'New');
            vm.$set(this.accessionState, 'accession', this.accessionState.accessionTemplate);
            vm.$set(this.accessionState, 'isNew', true);
        }

    }
};
/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(8)))

/***/ }),

/***/ 301:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


module.exports = {
    patientState: {
        loaded: false,
        isNew: false,
        isLoading: false,
        patientsSearched: false,
        mrn: "",
        patient: {
            "id": 0,
            "lastName": '',
            "firstName": '',
            "fullName": '',
            "dob": '',
            "dobString": '',
            "ssn": ''
        }
    }
};

/***/ }),

/***/ 302:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _PatientVueData = __webpack_require__(301);

var _PatientVueData2 = _interopRequireDefault(_PatientVueData);

var _vueMultiselect = __webpack_require__(79);

var _vueMultiselect2 = _interopRequireDefault(_vueMultiselect);

var _axios = __webpack_require__(40);

var _axios2 = _interopRequireDefault(_axios);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

//import debounce from 'lodash/debounce';

var uuidV1 = __webpack_require__(78);

module.exports = {
    name: "Patient",
    components: {
        Multiselect: _vueMultiselect2.default
    },
    data: function data() {
        return { patientState: _PatientVueData2.default.patientState };
    },
    props: {
        prop_patientId: Number,
        prop_mrn: String,
        prop_user: Object,
        prop_organization: Object,
        prop_patients: Array
    },
    computed: {
        computedDobDay: {
            get: function get() {
                var vm = this;
                if (vm.prop_patientId < 1) return '';
                return new Date(vm.patientState.patient.dob).getDate();
            },
            set: function set(value) {
                var vm = this;
                var tempDob = new Date(vm.patientState.patient.dob);
                tempDob.setDate(value);
                vm.$set(vm.patientState.patient, 'dob', tempDob);
            }
        },

        computedDobMonth: {
            get: function get() {
                var vm = this;
                if (vm.prop_patientId < 1) return '';
                return new Date(vm.patientState.patient.dob).getMonth() + 1;
            },
            set: function set(value) {
                var vm = this;
                var tempDob = new Date(vm.patientState.patient.dob);
                tempDob.setMonth(value - 1);
                vm.$set(vm.patientState.patient, 'dob', tempDob);
            }
        },

        computedDobYear: {
            get: function get() {
                var vm = this;
                if (vm.prop_patientId < 1) return '';
                return new Date(vm.patientState.patient.dob).getFullYear();
            },
            set: function set(value) {
                var vm = this;
                var tempDob = new Date(vm.patientState.patient.dob);
                tempDob.setFullYear(value);
                vm.$set(vm.patientState.patient, 'dob', tempDob);
            }
        }

    },
    created: function created() {
        if (this.prop_patientId > 0) {
            this.setPatient(this.prop_organization, this.prop_patientId, this.prop_mrn);
        } else this.newPatient();
    },
    beforeMount: function beforeMount() {
        //$('#dobField').daterangepicker({
        //    "singleDatePicker": true,
        //    "timePicker": false,
        //    locale: {
        //        format: 'MM/DD/YYYY'
        //    }
        //});
    },
    methods: {
        customPatientDropdownLabel: function customPatientDropdownLabel(patient) {
            if (patient.id == -1) return "Type to Search";else return 'Name: ' + patient.firstName + ' ' + patient.lastName + ', DOB: ' + this.dateFormat(patient.dob) + ', SSN: ' + patient.ssn;
        },

        allowEditSave: function allowEditSave() {
            return patientState.patientsSearched;
        },

        dateFormat: function dateFormat(date) {
            return this.$options.filters.MMDDYYYY(date);
        },

        limitText: function limitText(count) {
            return 'and ' + count + ' additional Patients';
        },

        patientSearched: function patientSearched(searchQuery, id) {
            this.patientState.patientsSearched = true;
        },

        patientChanged: function patientChanged(value, dropDownId, doReload) {
            this.$emit('changed', value.id, doReload);
        },

        //getDobString: function(dob){
        //    var dobDt = new Date(dob);
        //    return (dobDt.getMonth() + 1) + '/' + dobDt.getDay() + '/' + dobDt.getFullYear();
        //},

        newPatient: function newPatient() {
            this.patientState.patient = {
                "id": -1,
                "guid": uuidV1(),
                "lastName": '',
                "firstName": '',
                "fullName": '',
                "dob": '',
                //"dobString": '',
                "ssn": ''
            };
            this.patientState.mrn = "";
            this.$emit('new', -1);
        },

        setPatient: function setPatient(org, patientId, mrn) {
            var currentPatient = this.prop_patients.find(function (p) {
                return p.id == patientId;
            });
            if (currentPatient != null) {
                this.$set(this.patientState, 'patient', currentPatient);
                //done in compute - this.$set(this.patientState.patient, 'dobString', this.getDobString(this.patientState.patient.dob));
                this.$set(this.patientState, 'mrn', mrn);
            } else this.newPatient();
        },

        savePatient: function savePatient() {
            var _this = this;

            var vm = this;
            //vm.$set(vm.patientState.patient, 'dob', new Date(vm.patientState.patient.dobString).toJSON());
            //vm.$delete(vm.patientState.patient, 'dobString');
            _axios2.default.post('/api/patient', {
                patient: vm.patientState.patient,
                orgCustomData: vm.prop_organization.customData,
                userFullName: vm.prop_user.fullName,
                userHref: vm.prop_user.href }).then(function (response) {
                vm.$set(vm.patientState.patient, 'id', response.data.id);
                vm.$set(vm.patientState.patient, 'guid', response.data.guid);
                _this.patientChanged(vm.patientState.patient, response.data.id, true);
            });
        }

    }

};

/***/ }),

/***/ 303:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


module.exports = {
    specimensState: {
        loaded: false,
        isNew: false,
        isLoading: false
    }
};

/***/ }),

/***/ 304:
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function($) {

var _SpecimensVueData = __webpack_require__(303);

var _SpecimensVueData2 = _interopRequireDefault(_SpecimensVueData);

var _CivicGeneSelection = __webpack_require__(653);

var _CivicGeneSelection2 = _interopRequireDefault(_CivicGeneSelection);

var _vueMultiselect = __webpack_require__(79);

var _vueMultiselect2 = _interopRequireDefault(_vueMultiselect);

var _axios = __webpack_require__(40);

var _axios2 = _interopRequireDefault(_axios);

var _debounce = __webpack_require__(152);

var _debounce2 = _interopRequireDefault(_debounce);

var _customDataHelpers = __webpack_require__(60);

var _customDataHelpers2 = _interopRequireDefault(_customDataHelpers);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var uuidV1 = __webpack_require__(78);

module.exports = {
    name: "Specimens",
    components: {
        Multiselect: _vueMultiselect2.default,
        CivicGeneSelectionPlugin: _CivicGeneSelection2.default
    },
    mixins: [_customDataHelpers2.default],
    props: {
        specimens: Array,
        organization: Object
    },
    data: function data() {
        return {
            specimensState: _SpecimensVueData2.default.specimensState,
            civicGenesCache: []
        };
    },
    computed: {
        currentSpecimen: {
            get: function get() {
                var vm = this;
                var spec = null;
                if (vm.specimensState.editingSpecimenGuid === '' || vm.specimensState.editingSpecimenGuid === null) return spec;
                spec = vm.specimens.find(function (s) {
                    return s.guid === vm.specimensState.editingSpecimenGuid;
                });
                if (typeof spec !== 'undefined') {
                    var cD = new Date(spec.collectionDate);
                    //function... filter?
                    spec.collectionDate = this.$options.filters.MMDDYYYYhhmm(spec.collectionDate);
                }
                return spec;
            },
            set: function set(value) {
                var vm = this;
                var index = vm.specimens.findIndex(function (s) {
                    return s.guid = value.guid;
                });
                value.collectionDate = new Date(value.collectionDate).toJSON();
                vm.specimens.$set(index, value);
            }
        }
    },
    beforeMount: function beforeMount() {},
    mounted: function mounted() {
        this.toolTips();
    },

    methods: {

        //not working!
        toolTips: function toolTips() {
            this.$nextTick(function () {
                $('[data-toggle="tooltip"]').tooltip();
            });
        },

        //component event
        changed: function changed() {
            this.$emit('changed', this.specimens);
        },

        //have to consider using a plugin vuex store or similar so a plugin can access global data
        cacheCivicGenes: function cacheCivicGenes(genes) {
            var vm = this;
            vm.$set(vm, 'civicGenesCache', genes);
        },

        currentSpecimenTypeTransportChanged: function currentSpecimenTypeTransportChanged() {
            var spec = this.currentSpecimen;
            var type = this.organizationSpecimenTypes.find(function (t) {
                return t.code === spec.type.code;
            });
            var transport = this.getSpecimenTransports(type.code).find(function (t) {
                return t.code === spec.transport.code;
            });
            if (transport === null) spec.code = type.code;else spec.code = type.code + '-' + transport.code;
        },

        addSpecimen: function addSpecimen(type) {
            var newSpec = {
                guid: uuidV1(),
                id: -1,
                parentSpecimenGuid: '00000000-0000-0000-0000-000000000000',
                type: { type: type.type, code: type.code },
                code: type.code, //temp
                transport: { name: null, code: null },
                externalSpecimenID: null,
                customData: {},
                collectionDate: new Date(new Date() - 1).toJSON(),
                receivedDate: new Date().toJSON(),
                category: null
                //attributesAreSet: false
            };

            this.setSpecimenAttributes(newSpec);

            this.specimens.push(newSpec);

            this.$set(this.specimensState, 'editingSpecimenGuid', newSpec.guid);

            this.$nextTick(function () {
                this.setExpandedSpecimen(true);
            });
        },

        copySpecimenFromPrevious: function copySpecimenFromPrevious(specimen) {},

        specimenClicked: function specimenClicked(specimen) {
            var expand = false;
            if (specimen.guid === this.specimensState.editingSpecimenGuid) {
                this.$set(this.specimensState, 'editingSpecimenGuid', '');
            } else {
                this.$set(this.specimensState, 'editingSpecimenGuid', specimen.guid);
                this.setSpecimenAttributes(specimen);
                expand = true;
            }
            this.$nextTick(function () {
                this.setExpandedSpecimen(expand);
            });
        },

        setExpandedSpecimen: function setExpandedSpecimen(expandCurrent) {
            var vm = this;
            this.specimens.forEach(function (s) {
                var specCollapse = $('#collapse' + s.guid);
                var isShown = specCollapse._isShown;
                if (s == vm.currentSpecimen && expandCurrent && !isShown) specCollapse.collapse('show');else if (isShown) specCollapse.collapse('hide');
            });

            //do this while we're here
            $('.dateTimePicker').daterangepicker({
                "singleDatePicker": true,
                "timePicker": true,
                "timePicker24Hour": true,
                locale: {
                    format: 'MM/DD/YYYY h:mm'
                }
            });
        }

        //expandCurrentSpecimen: function(){
        //    $('#collapse'+this.currentSpecimen.guid).collapse('show');
        //},

        //collapseNonCurrentSpecimens: function() {
        //    var vm = this;
        //    this.specimens.forEach(function(s){
        //        if(vm.currentSpecimen === null || s.guid !== vm.currentSpecimen.guid)
        //            $('#collapse'+s.guid).collapse('hide');
        //    });
        //}

    }
};
/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(8)))

/***/ }),

/***/ 305:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


module.exports = {
    accessionInfoState: {
        options: {}
    }
};

/***/ }),

/***/ 306:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _AccessionInfoVueData = __webpack_require__(305);

var _AccessionInfoVueData2 = _interopRequireDefault(_AccessionInfoVueData);

var _customDataHelpers = __webpack_require__(60);

var _customDataHelpers2 = _interopRequireDefault(_customDataHelpers);

var _worklistLookup = __webpack_require__(318);

var _worklistLookup2 = _interopRequireDefault(_worklistLookup);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

module.exports = {
    name: "AccessionInfo",
    props: {
        organization: Object,
        accession: Object,
        clients: Array,
        labs: Array,
        patients: Array,
        doctors: Array
    },
    components: {},
    mixins: [_customDataHelpers2.default, _worklistLookup2.default],
    methods: {
        loadLookupData: function loadLookupData() {
            axios.all([axios.get('/api/Client/' + org.nameKey), axios.get('/api/Lab/' + org.nameKey), axios.get('/api/Doctor/' + org.nameKey), axios.get('/api/Patient/' + org.nameKey)]).then(axios.spread(function (clientResponse, labResponse, doctorResponse, patientResponse) {
                vm.$set(vm.state, 'clients', clientResponse.data);
                vm.$set(vm.state, 'labs', clientResponse.data);
                vm.$set(vm.state, 'doctors', clientResponse.data);
                vm.$set(vm.state, 'patients', clientResponse.data);
            })).catch(function (err) {
                console.log(err);
            });
        }
    }
};

/***/ }),

/***/ 307:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


module.exports = {
    worklistState: {
        config: {
            start: '01-01-2017',
            end: '03-01-2017',
            options: {
                includeCases: false,
                includeSpecimens: true
            }
        }
    },
    worklist: {}
};

/***/ }),

/***/ 308:
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function($) {

var _WorklistVueData = __webpack_require__(307);

var _WorklistVueData2 = _interopRequireDefault(_WorklistVueData);

var _axios = __webpack_require__(40);

var _axios2 = _interopRequireDefault(_axios);

var _WorklistSpecimens = __webpack_require__(645);

var _WorklistSpecimens2 = _interopRequireDefault(_WorklistSpecimens);

var _AccessionInfo = __webpack_require__(641);

var _AccessionInfo2 = _interopRequireDefault(_AccessionInfo);

var _WorklistCaseDetail = __webpack_require__(643);

var _WorklistCaseDetail2 = _interopRequireDefault(_WorklistCaseDetail);

var _customDataHelpers = __webpack_require__(60);

var _customDataHelpers2 = _interopRequireDefault(_customDataHelpers);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

//rename to worklist..
var urlencode = __webpack_require__(627);

module.exports = {
    name: "Worklist",
    components: {
        WorklistSpecimens: _WorklistSpecimens2.default,
        AccessionInfo: _AccessionInfo2.default,
        WorklistCaseDetail: _WorklistCaseDetail2.default
    },
    mixins: [_customDataHelpers2.default],
    props: {
        organization: Object
    },
    data: function data() {
        return {
            state: _WorklistVueData2.default.worklistState,
            worklist: _WorklistVueData2.default.worklist
        };
    },
    methods: {
        applyDataTables: function applyDataTables() {
            var vm = this;
            this.$nextTick(function () {
                var table = $('#worklistTable').DataTable({
                    buttons: [{ extend: 'copy', className: 'btn-primary float-right mr-1 ml-1' }, 'excel', 'pdf', { extend: 'colvis', className: 'btn-primary float-right mr-1 ml-1', text: "Columns" }],
                    columnDefs: [{
                        //"targets": 1,
                        //"data": "createdDate",
                        //"render": function ( data, type, full, meta ) {
                        //    return vm.$options.filters.localeDate(data);
                        //}
                    }]
                });
                table.buttons().container().appendTo($('.col-sm-6:eq(0)', table.table().container()));
            });
        },

        loadData: function loadData(org, config) {
            var vm = this;
            var worklistUrl = '/api/Worklist/' + org.nameKey + '/' + config.start + '/' + config.end + '/' + urlencode(JSON.stringify(config.options));

            _axios2.default.all([_axios2.default.get(worklistUrl), _axios2.default.get('/api/Client/' + org.nameKey), _axios2.default.get('/api/Lab/' + org.nameKey), _axios2.default.get('/api/Doctor/' + org.nameKey), _axios2.default.get('/api/Patient/' + org.nameKey)]).then(_axios2.default.spread(function (worklistResponse, clientResponse, labResponse, doctorResponse, patientResponse) {

                vm.$set(vm, 'worklist', worklistResponse.data);
                vm.$set(vm.state, 'clients', clientResponse.data);
                vm.$set(vm.state, 'labs', clientResponse.data);
                vm.$set(vm.state, 'doctors', clientResponse.data);
                vm.$set(vm.state, 'patients', clientResponse.data);
                //apply after last data load
                vm.applyDataTables();
            })).catch(function (err) {
                console.log(err);
            });
        },
        setWorklistConfig: function setWorklistConfig(org) {
            this.state.config.start = Date.now() - 30;
            this.state.config.end = Date.now();
            this.state.config.options.includeCases = this.organizationUsesCases;
            this.state.config.options.includeSpecimens = this.organizationUsesSpecimens;
        }
    },
    created: function created() {
        this.setWorklistConfig(this.organization);
        this.loadData(this.organization, this.state.config);
    }
};
/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(8)))

/***/ }),

/***/ 309:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


module.exports = {
    caseState: {
        options: {}
    }
};

/***/ }),

/***/ 310:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _WorklistCaseDetailVueData = __webpack_require__(309);

var _WorklistCaseDetailVueData2 = _interopRequireDefault(_WorklistCaseDetailVueData);

var _customDataHelpers = __webpack_require__(60);

var _customDataHelpers2 = _interopRequireDefault(_customDataHelpers);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

module.exports = {
    name: "WorklistCaseDetail",
    props: {
        organization: Object,
        _case: Object
    },
    components: {},
    mixins: [_customDataHelpers2.default],
    data: function data() {
        return {
            //case: caseState.case,
            options: _WorklistCaseDetailVueData2.default.options
        };
    },
    methods: {}
};

/***/ }),

/***/ 311:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


module.exports = {
    specimenState: {
        options: {}
    }
};

/***/ }),

/***/ 312:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _WorklistSpecimenDetailVueData = __webpack_require__(311);

var _WorklistSpecimenDetailVueData2 = _interopRequireDefault(_WorklistSpecimenDetailVueData);

var _customDataHelpers = __webpack_require__(60);

var _customDataHelpers2 = _interopRequireDefault(_customDataHelpers);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

module.exports = {
    name: "WorklistSpecimenDetail",
    props: {
        organization: Object,
        specimen: Object
    },
    components: {},
    mixins: [_customDataHelpers2.default],
    data: function data() {
        return {
            //specimen: specimenState.specimen,
            options: _WorklistSpecimenDetailVueData2.default.options
        };
    },
    methods: {}
};

/***/ }),

/***/ 313:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


module.exports = {
    specimensState: {
        options: {}
    }
};

/***/ }),

/***/ 314:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _WorklistSpecimensVueData = __webpack_require__(313);

var _WorklistSpecimensVueData2 = _interopRequireDefault(_WorklistSpecimensVueData);

var _WorklistSpecimenDetail = __webpack_require__(644);

var _WorklistSpecimenDetail2 = _interopRequireDefault(_WorklistSpecimenDetail);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

module.exports = {
    name: "WorklistSpecimens",
    props: {
        organization: Object,
        specimens: Array
    },
    components: {
        WorklistSpecimenDetail: _WorklistSpecimenDetail2.default
    }
};

/***/ }),

/***/ 315:
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function($) {

module.exports = {
    name: 'ScanLookup',
    data: function data() {
        return {
            currentAction: {
                name: 'scan',
                label: 'Scan Specimen'
            },
            actions: [{
                name: 'scan',
                label: 'Scan Specimen'
            }, {
                name: 'lookup',
                label: 'Enter Alternate ID'
            }],
            value: ''
        };
    },
    mounted: function mounted() {
        $('.focusDefault').focus();
    },
    methods: {
        scanLookup: function scanLookup(event) {
            var vm = this;
            vm.$emit('scanLookup', vm.currentAction.name, vm.value);
            vm.$set(vm, 'value', '');
        },
        setAction: function setAction(action) {
            this.$set(this, 'currentAction', action);
            $('.focusDefault').focus();
        }
    }
};
/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(8)))

/***/ }),

/***/ 316:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.domain = domain;
exports.count = count;
exports.prettyDate = prettyDate;
exports.MMDDYYYY = MMDDYYYY;
exports.MMDDYYYYhhmm = MMDDYYYYhhmm;
exports.localeDate = localeDate;
exports.localeDateOrTimeToday = localeDateOrTimeToday;
exports.truncate = truncate;
var urlParser = document.createElement('a');

function domain(url) {
    urlParser.href = url;
    return urlParser.hostname;
}

function count(arr) {
    return arr.length;
}

function prettyDate(date) {
    var a = new Date(date);
    if (isNaN(a.getTime())) return '';
    return a.toDateString();
}

function MMDDYYYY(date) {
    var a = new Date(date);
    if (isNaN(a.getTime())) return '';
    return a.getDay() + '/' + a.getMonth() + '/' + a.getFullYear();
}

function MMDDYYYYhhmm(date) {
    var a = new Date(date);
    if (isNaN(a.getTime())) return '';
    return a.getMonth() + 1 + '/' + a.getDate() + '/' + a.getFullYear() + ' ' + ("00" + a.getHours()).slice(2) + ':' + ("00" + a.getMinutes()).slice(2);
}

function localeDate(date) {
    var a = new Date(date);
    if (isNaN(a.getTime())) return '';
    return a.toLocaleString();
}

function localeDateOrTimeToday(date) {
    var a = new Date(date);
    var todayDate = new Date().toLocaleDateString();
    if (isNaN(a.getTime())) return '';
    if (a.toLocaleDateString() !== todayDate) return todayDate;
    return a.toLocaleTimeString();
}

//export function pluralize (time, label) { //see vue2-filters
//    if (time === 1) {
//        return time + label
//    }

//    return time + label + 's'
//}

function truncate(string) {
    return string.substring(0, 24) + '...';
}

/***/ }),

/***/ 317:
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function($) {

var _vue = __webpack_require__(51);

var _vue2 = _interopRequireDefault(_vue);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

_vue2.default.mixin({
    methods: {
        setLogo: function setLogo(vm) {
            if (typeof vm.organization.customData.logoUrl != 'undefined' && vm.organization.customData.logoUrl != '') $(".navbar-brand").css("background-image", 'url(' + vm.organization.customData.logoUrl + ')');
            $(".navbar-brand").css('display', 'inline-block');
        },
        setCSS: function setCSS(vm) {
            if (typeof vm.organization.customData.logoUrl != 'undefined') {
                //$('head').append('<link rel="stylesheet" type="text/css" href="http://vault.immunovault.com/Content/themes/maincss/style.css">');
            }
        }
        //colorReplace:function (findHexColor, replaceWith) {
        //    // Convert rgb color strings to hex
        //    function rgb2hex(rgb) {
        //        if (/^#[0-9A-F]{6}$/i.test(rgb)) return rgb;
        //        rgb = rgb.match(/^rgb\((\d+),\s*(\d+),\s*(\d+)\)$/);
        //        function hex(x) {
        //            return ("0" + parseInt(x).toString(16)).slice(-2);
        //        }
        //        return "#" + hex(rgb[1]) + hex(rgb[2]) + hex(rgb[3]);
        //    }

        //    // Select and run a map function on every tag
        //    $('*').map(function (i, el) {
        //        // Get the computed styles of each tag
        //        var styles = window.getComputedStyle(el);

        //        // Go through each computed style and search for "color"
        //        Object.keys(styles).reduce(function (acc, k) {
        //            var name = styles[k];
        //            var value = styles.getPropertyValue(name);
        //            if (value !== null && name.indexOf("color") >= 0) {
        //                // Convert the rgb color to hex and compare with the target color
        //                if (value.indexOf("rgb(") >= 0 && rgb2hex(value) === findHexColor) {
        //                    // Replace the color on this found color attribute
        //                    $(el).css(name, replaceWith);
        //                }
        //            }
        //        });
        //    });
        //},
    } });
/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(8)))

/***/ }),

/***/ 318:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _vue = __webpack_require__(51);

var _vue2 = _interopRequireDefault(_vue);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

_vue2.default.mixin({
    methods: {
        lookup: function lookup(type, value, data) {
            switch (type) {
                case "lab":
                case "client":
                default:
                    var retVal = data.find(function (c) {
                        return c.id == value;
                    });
                    if (typeof retVal != 'undefined') return retVal;else return new {
                        id: 0,
                        name: 'Unknown'
                    }();
                    break;
            }
        }
    }
}); //nevermind this

/***/ }),

/***/ 319:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _Main = __webpack_require__(634);

var _Main2 = _interopRequireDefault(_Main);

var _ClientAdmin = __webpack_require__(638);

var _ClientAdmin2 = _interopRequireDefault(_ClientAdmin);

var _Tables = __webpack_require__(651);

var _Tables2 = _interopRequireDefault(_Tables);

var _Tasks = __webpack_require__(652);

var _Tasks2 = _interopRequireDefault(_Tasks);

var _Setting = __webpack_require__(649);

var _Setting2 = _interopRequireDefault(_Setting);

var _Mailbox = __webpack_require__(633);

var _Mailbox2 = _interopRequireDefault(_Mailbox);

var _ = __webpack_require__(631);

var _2 = _interopRequireDefault(_);

var _Accessioning = __webpack_require__(635);

var _Accessioning2 = _interopRequireDefault(_Accessioning);

var _Worklist = __webpack_require__(642);

var _Worklist2 = _interopRequireDefault(_Worklist);

var _DashboardContainer = __webpack_require__(640);

var _DashboardContainer2 = _interopRequireDefault(_DashboardContainer);

var _SpecimenTrackingDashboard = __webpack_require__(655);

var _SpecimenTrackingDashboard2 = _interopRequireDefault(_SpecimenTrackingDashboard);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

//import Server from './components/main/Server.vue'

//import GenericDashboard1 from './components/main/GenericDashboard1.vue'
//import GenericDashboard2 from './components/main/GenericDashboard2.vue'
var routes = [{
    path: '/',
    component: _Main2.default,
    name: 'Dashboards',
    children: [{
        path: '',
        redirect: 'dashboard/user',
        meta: {
            showInNavMenu: false
        }
    }, {
        path: 'dashboard/user/:id?',
        component: _DashboardContainer2.default,
        name: 'My Dashboard',
        meta: {
            title: 'My Dashboard',
            iconClass: 'fa fa-th-large'
        }
    }]
}, {
    path: '/',
    component: _Main2.default,
    name: 'Sample Management',
    description: '',
    meta: { title: 'Sample Management' },
    children: [{
        path: 'accessioning/:id/:orgNameKey',
        component: _Accessioning2.default,
        name: 'Edit Accession',
        description: 'Edit sample/accession',
        meta: {
            title: 'Accessioning',
            showInNavMenu: false,
            hasHistoryItems: true,
            historyItemName: 'Accessions'
        }
    }, {
        path: 'accessioning',
        component: _Accessioning2.default,
        name: 'New Accession',
        description: 'Add sample/accession to the system',
        meta: {
            title: 'Accessioning',
            iconClass: 'fa fa-plus',
            hasHistoryItems: true,
            historyItemName: 'Accessions'
        }
    }, {
        path: 'dashboard/specimentracking',
        component: _SpecimenTrackingDashboard2.default,
        name: 'Specimen Tracking',
        description: 'Track and review specimen status/location',
        meta: {
            title: 'Specimen Tracking Dashboard',
            iconClass: 'fa fa-map-marker'
        }
    }]
}, {
    path: '/',
    component: _Main2.default,
    name: 'Lists',
    description: '',
    meta: { title: 'Lists' },
    children: [{
        path: 'list/worklist/catalog',
        component: _Worklist2.default,
        name: 'Specimen Catalog',
        description: '',
        meta: {
            title: 'Catalog',
            iconClass: 'fa fa-shopping-cart'
        }
    }, {
        path: 'list/worklist/inventory',
        component: _Worklist2.default,
        name: 'Specimen Inventory',
        description: '',
        meta: {
            title: 'Inventory',
            iconClass: "icon-chemistry"
        }
    }, {
        path: 'list/worklist/specimens',
        component: _Worklist2.default,
        name: 'Specimen Worklist',
        description: '',
        meta: { title: 'Worklist',
            iconClass: 'fa fa-tasks'
        }
    }, {
        path: 'list/worklist/cases',
        component: _Worklist2.default,
        name: 'Case Worklist',
        description: '',
        meta: { title: 'Worklist' }
    }]
}, {
    path: '/',
    component: _Main2.default,
    name: 'Tools',
    description: '',
    meta: { title: 'Tools' },
    children: [{
        path: 'admin/clientadmin',
        component: _ClientAdmin2.default,
        name: 'Client Admin',
        description: 'Client Administration',
        meta: { title: 'Client Admin' }
    }, {
        path: 'setting',
        component: _Setting2.default,
        name: 'Settings',
        description: 'User settings page',
        meta: { title: 'Settings' }
    }, {
        path: 'mailbox',
        component: _Mailbox2.default,
        name: 'Mailbox',
        meta: { title: 'Mailbox' }
    }]
}, {
    // not found handler
    path: '*',
    component: _2.default
}];

exports.default = routes;

/***/ }),

/***/ 320:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _vue = __webpack_require__(51);

var _vue2 = _interopRequireDefault(_vue);

var _vuex = __webpack_require__(65);

var _vuex2 = _interopRequireDefault(_vuex);

var _store = __webpack_require__(325);

var _store2 = _interopRequireDefault(_store);

var _store3 = __webpack_require__(323);

var _store4 = _interopRequireDefault(_store3);

var _store5 = __webpack_require__(321);

var _store6 = _interopRequireDefault(_store5);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

_vue2.default.use(_vuex2.default);

var store = new _vuex2.default.Store({
    modules: {
        user: _store2.default,
        organization: _store4.default,
        history: _store6.default
    },

    mutations: {
        TOGGLE_LOADING: function TOGGLE_LOADING(state) {
            state.callingAPI = !state.callingAPI;
        },
        TOGGLE_SEARCHING: function TOGGLE_SEARCHING(state) {
            state.searching = state.searching === '' ? 'loading' : '';
        }
    }

});

exports.default = store;

/***/ }),

/***/ 321:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _vue = __webpack_require__(51);

var _vue2 = _interopRequireDefault(_vue);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var organizationModule = {
    state: {
        historyItems: []
    },
    namespaced: true,
    getters: {
        historyItems: function historyItems(state) {
            return state.historyItems;
        }
    }
};

exports.default = organizationModule;

/***/ }),

/***/ 322:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.saveOrganization = exports.loadOrganization = undefined;

var _axios = __webpack_require__(40);

var _axios2 = _interopRequireDefault(_axios);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var loadOrganization = exports.loadOrganization = function loadOrganization(_ref) {
    var commit = _ref.commit;

    _axios2.default.get('/api/Organization/Get').then(function (response) {
        commit("LOAD_ORGANIZATION", response.data);
    }).catch(function (err) {
        console.log(err);
    });
};

var saveOrganization = exports.saveOrganization = function saveOrganization(_ref2, organization) {
    var commit = _ref2.commit;

    _axios2.default.post('/api/Organization/Save/', JSON.parse(organization)).then(function (response) {
        commit("SAVE_ORGANIZATION", response.data);
    }).catch(function (err) {
        console.log(err);
    });
};

/***/ }),

/***/ 323:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _actions = __webpack_require__(322);

var _vue = __webpack_require__(51);

var _vue2 = _interopRequireDefault(_vue);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var organizationModule = {
    state: {
        loaded: false,
        organization: {
            "href": null,
            "name": null,
            "nameKey": null,
            "groups": [{
                "name": null,
                "users": [{
                    "href": null,
                    "email": null,
                    "fullName": null
                }]
            }]
        }
    },
    namespaced: true,
    mutations: {
        LOAD_ORGANIZATION: function LOAD_ORGANIZATION(state, payload) {
            _vue2.default.set(state.organization, "customData", payload.customData);
            Object.assign(state.organization, payload);
            state.loaded = true;
        },
        SAVE_ORGANIZATION: function SAVE_ORGANIZATION(state, payload) {}
    },

    actions: {
        loadOrganization: _actions.loadOrganization,
        saveOrganization: _actions.saveOrganization
    },

    getters: {
        organization: function organization(state) {
            return state.organization;
        },
        organizationLoaded: function organizationLoaded(state) {
            return state.loaded;
        }
    }
};

exports.default = organizationModule;

/***/ }),

/***/ 324:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.updateCustomData = exports.getUser = undefined;

var _axios = __webpack_require__(40);

var _axios2 = _interopRequireDefault(_axios);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var getUser = exports.getUser = function getUser(_ref) {
    var commit = _ref.commit;

    _axios2.default.get('/me').then(function (response) {
        commit("GET_USER", response.data);
    }).catch(function (err) {
        console.log(err);
    });
};
var updateCustomData = exports.updateCustomData = function updateCustomData(_ref2) {
    var commit = _ref2.commit;

    _axios2.default.post('/api/User/UpdateCustomData', {
        Key: 'messages',
        Value: '[{"date": "2012-04-23T18:25:43.511Z","source": "SystemNotifications","read": "frue","expires": "2017-04-23T18:25:43.511Z","message": "Sample message #1"},{"date": "2012-04-24T18:29:22.511Z","source": "SystemNotifications","read": "false","expires": "2017-04-24T18:29:22.511Z","message": "Sample message #2"}]'
    }).then(function (response) {
        commit("UPDATE_CUSTOM_DATA", response.data);
    }).catch(function (err) {
        console.log(err);
    });
};

/***/ }),

/***/ 325:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _actions = __webpack_require__(324);

var userModule = {
    state: {
        loaded: false,
        user: {
            href: null,
            userName: null,
            email: null,
            givenName: null,
            middleName: null,
            surname: null,
            fullName: null,
            createdAt: null,
            modifiedAt: null,
            passwordModifiedAt: null,
            emailVerificationToken: null,
            status: null,
            customData: {
                "createdAt": null,
                "href": null,
                "modifiedAt": null,
                messages: [],
                notifications: [],
                tasks: []
            },
            groups: {
                size: null,
                items: []
            }
        }
    },
    namespaced: true,
    mutations: {
        GET_USER: function GET_USER(state, payload) {
            Object.assign(state.user, payload.account);

            //dummy data
            state.user.customData.messages = [{ id: "1", from: "Kyle Dunn", subject: "Message 1", text: "Message 1 is abc 123 def 456 ghi 789", timeStamp: "2012-04-23T18:25:43.000Z", read: true }, { id: "2", from: "Ian Field", subject: "Message 2", text: "Message 2 is abc 123 def 456 ghi 789", timeStamp: "2012-04-23T18:29:41.000Z", read: false }];

            state.user.messageCount = 0;
            state.user.hasMessages = typeof state.user.customData.messages !== 'undefined' && state.user.customData.messages.length > 0;
            if (state.user.hasMessages) state.user.messageCount = state.user.customData.messages.length;

            state.user.notificationCount = 0;
            state.user.hasNotifications = typeof state.user.customData.notifications !== 'undefined' && state.user.customData.notifications.length > 0;
            if (state.user.hasNotifications) state.user.notificationCount = state.user.customData.notifications.length;

            state.user.taskCount = 0;
            state.user.hasTasks = typeof state.user.customData.tasks !== 'undefined' && state.user.customData.tasks.length > 0;
            if (state.user.hasTasks) state.user.taskCount = state.user.customData.tasks.length;

            if (!state.user.groups.items) state.user.groups.items = [];

            state.loaded = true;
        },

        UPDATE_CUSTOM_DATA: function UPDATE_CUSTOM_DATA(state, payload) {}
    },

    actions: {
        getUser: _actions.getUser,
        updateCustomData: _actions.updateCustomData
    },

    getters: {
        user: function user(state) {
            return state.user;
        },
        userLoaded: function userLoaded(state) {
            return state.loaded;
        }
    }
};

exports.default = userModule;

/***/ }),

/***/ 326:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
  value: true
});
//
//
//
//
//
//
//
//
//
//
//
//
//
//

exports.default = {
  name: 'NotFound'
};

/***/ }),

/***/ 327:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


//
//
//
//
//

module.exports = {
    name: 'App'
};

/***/ }),

/***/ 328:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _extends = Object.assign || function (target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i]; for (var key in source) { if (Object.prototype.hasOwnProperty.call(source, key)) { target[key] = source[key]; } } } return target; }; //
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

var _vuex = __webpack_require__(65);

//import store from '../store/index.js';
module.exports = {
    name: 'Mailbox',
    //store: function () {
    //    return this.$parent.$parent.$store;
    //},
    //state: function () {
    //    return this.store.state;
    //},
    computed: _extends({}, (0, _vuex.mapGetters)('user', ['user']))
};

/***/ }),

/***/ 329:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _extends = Object.assign || function (target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i]; for (var key in source) { if (Object.prototype.hasOwnProperty.call(source, key)) { target[key] = source[key]; } } } return target; }; //
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

var _vuex = __webpack_require__(65);

var _Sidebar = __webpack_require__(650);

var _Sidebar2 = _interopRequireDefault(_Sidebar);

var _SecondarySidebar = __webpack_require__(648);

var _SecondarySidebar2 = _interopRequireDefault(_SecondarySidebar);

var _Navbar = __webpack_require__(647);

var _Navbar2 = _interopRequireDefault(_Navbar);

var _AppFooter = __webpack_require__(646);

var _AppFooter2 = _interopRequireDefault(_AppFooter);

var _organizationStyle = __webpack_require__(317);

var _organizationStyle2 = _interopRequireDefault(_organizationStyle);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

module.exports = {
    name: 'Main',
    components: {
        'Sidebar': _Sidebar2.default,
        'Navbar': _Navbar2.default,
        'SecondarySidebar': _SecondarySidebar2.default,
        'AppFooter': _AppFooter2.default
    },
    //data: function(){
    //    historyItems: []
    //},
    mixins: [_organizationStyle2.default],
    methods: {
        postOrgLoadActions: function postOrgLoadActions(vm) {
            window.document.title = vm.organization.name + ' - ' + vm.$route.meta.title;
            this.setLogo(vm);
            this.setCSS(vm);
        },
        startOrgWatcher: function startOrgWatcher(vm) {
            vm.$parent.$store.watch(function (state) {
                return state.organization.loaded;
            }, function () {
                if (vm.organizationLoaded) vm.$nextTick(function () {
                    vm.postOrgLoadActions(vm);
                });
            });
        },
        setHistoryItem: function setHistoryItem(view, id, title, headline, content, date) {
            var vm = this;
            var itemIndex = vm.historyItems.findIndex(function (h) {
                return h.id === id && h.view === view;
            });
            var item = { view: view, id: id, title: title, headline: headline, content: content, timeStamp: date };
            if (itemIndex > -1) vm.$set(vm.historyItems, itemIndex, item);else vm.historyItems.push(item);
        }
    },
    watch: {
        '$route': function $route() {
            if (this.organizationLoaded) this.postOrgLoadActions(this);else this.startOrgWatcher(this);
        }
    },
    created: function created() {
        var vm = this;
        if (!this.userLoaded) this.$parent.$store.dispatch('user/getUser');
        if (!this.organizationLoaded) {
            this.$parent.$store.dispatch('organization/loadOrganization');
        }
        this.startOrgWatcher(this);
    },
    computed: _extends({}, (0, _vuex.mapGetters)('user', ['user', 'userLoaded']), (0, _vuex.mapGetters)('organization', ['organization', 'organizationLoaded']), (0, _vuex.mapGetters)('history', ['historyItems']))
};

/***/ }),

/***/ 330:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _Organization = __webpack_require__(639);

var _Organization2 = _interopRequireDefault(_Organization);

var _vuex = __webpack_require__(65);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

module.exports = {
    name: 'ClientAdmin',
    components: { 'Organization': _Organization2.default },
    computed: {},
    created: function created() {},
    mounted: function mounted() {}
};

/***/ }),

/***/ 331:
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function($) {

var _extends = Object.assign || function (target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i]; for (var key in source) { if (Object.prototype.hasOwnProperty.call(source, key)) { target[key] = source[key]; } } } return target; }; //
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//


//continue using vuex for organization as it does have a global presence.  remember not to use v-model for two-way bindable fields.


var _vuex = __webpack_require__(65);

module.exports = {
    name: 'Organization',
    computed: _extends({
        set: function set(org) {
            this.$parent.$store.dispatch('organization/setOrganization', org);
        }
    }, (0, _vuex.mapGetters)('organization', ['organization']), (0, _vuex.mapGetters)('user', ['user'])),
    mounted: function mounted() {
        setupFormOverlays();
    }
};

var setupFormOverlays = function setupFormOverlays() {

    $('#select2').select2();

    $('input[name="demo"]').daterangepicker({
        "singleDatePicker": true,
        "timePicker": true,
        "startDate": "07/01/2015",
        "endDate": "07/15/2015",
        locale: {
            format: 'MM/DD/YYYY h:mm A'
        }
    });
};
/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(8)))

/***/ }),

/***/ 332:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


//
//
//
//
//
//
//
//


module.exports = {
    name: 'DashboardContainer',
    watch: {
        '$route': function $route() {
            window.document.title = vm.organization.name + ' - ' + vm.$route.meta.title;
        }
    }
};

/***/ }),

/***/ 333:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _moment = __webpack_require__(0);

var _moment2 = _interopRequireDefault(_moment);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

module.exports = {
    name: 'AppFooter',
    props: {
        organization: Object
    },
    computed: {
        year: function year() {
            return (0, _moment2.default)().format('YYYY');
        }
    }
}; //
//
//
//
//
//
//

/***/ }),

/***/ 334:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//


module.exports = {
    name: 'Navbar',
    props: {
        user: Object,
        organization: Object
    }
};

/***/ }),

/***/ 335:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//


module.exports = {
    name: 'SecondarySidebar',
    props: {
        user: Object,
        organization: Object,
        historyItems: Array
    }
};

/***/ }),

/***/ 336:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
  value: true
});

var _vueDatePicker = __webpack_require__(656);

var _vueDatePicker2 = _interopRequireDefault(_vueDatePicker);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

__webpack_require__(0);
exports.default = {
  name: 'Settings',
  computed: {
    datetime: function datetime() {
      return new Date();
    }
  },
  components: { datepicker: _vueDatePicker2.default },
  methods: {
    clearInput: function clearInput(vueModel) {
      vueModel = '';
    }
  },
  mounted: function mounted() {}
};

/***/ }),

/***/ 337:
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function(__webpack_provided_window_dot_$) {

//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

module.exports = {
    name: 'Sidebar',
    computed: {
        changeloading: function changeloading() {
            this.store.dispatch('TOGGLE_SEARCHING');
        },
        toggleMenu: function toggleMenu(event) {
            // remove active from li
            __webpack_provided_window_dot_$('li.pageLink').removeClass('active');
            // Add it to the item that was clicked
            event.toElement.parentElement.className = 'nav-item active';
        },
        defaultRouteIconClasses: function defaultRouteIconClasses() {
            return "fa fa-list";
        }
    }
};
/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(8)))

/***/ }),

/***/ 338:
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function($) {

//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//


module.exports = {
  name: 'Tables',
  mounted: function mounted() {
    this.$nextTick(function () {
      $('#example1').DataTable();
    });
  }
};
/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(8)))

/***/ }),

/***/ 339:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
  value: true
});

var _moment = __webpack_require__(0);

var _moment2 = _interopRequireDefault(_moment);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

exports.default = {
  name: 'Tasks',
  computed: {
    today: function today() {
      return (0, _moment2.default)().format('MMM Do YY');
    },
    timeline: function timeline() {
      return [{
        icon: 'fa-envelope',
        color: 'blue',
        title: 'Write short novel',
        time: (0, _moment2.default)().endOf('day').fromNow(),
        body: 'Etsy doostang zoodles disqus groupon greplin oooj voxy zoodles, weebly ning heekya handango imeem plugg dopplr jibjab, movity jajah plickers sifteo edmodo ifttt zimbra. Babblely odeo kaboodle quora plaxo ideeli hulu weebly balihoo...',
        buttons: [{
          type: 'primary',
          message: 'Read more'
        }]
      }, {
        icon: 'fa-user',
        color: 'yellow',
        title: 'Sarah Young accepted your friend request',
        time: (0, _moment2.default)('20150620', 'MMM Do YY').fromNow()
      }, {
        icon: 'fa-camera',
        color: 'purple',
        title: 'Watch a youTube video',
        time: (0, _moment2.default)('20130620', 'YYYYMMDD').fromNow(),
        body: '<div class="embed-responsive embed-responsive-16by9"><iframe width="560" height="315" src="https://www.youtube.com/embed/8aGhZQkoFbQ" frameborder="0" allowfullscreen></iframe></div>'
      }];
    }
  },
  methods: {
    mounted: function mounted() {
      // debugger
      // this.callGitHub()
      console.log('inside of task');
    }
  }
}; //
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/***/ }),

/***/ 340:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _vueMultiselect = __webpack_require__(79);

var _vueMultiselect2 = _interopRequireDefault(_vueMultiselect);

var _axios = __webpack_require__(40);

var _axios2 = _interopRequireDefault(_axios);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

//
//
//
//
//
//
//
//
//
//
//
//

module.exports = {
    name: "CivicGeneSelection",
    components: {
        Multiselect: _vueMultiselect2.default
    },
    props: {
        prop_value: Array,
        prop_id: String,
        prop_genes: Array
    },
    data: function data() {
        return {
            genes: []
        };
    },
    created: function created() {
        this.checkGenes();
    },
    methods: {
        genesRetrieved: function genesRetrieved(genes) {
            //allow parent to cache genes //have to consider using a plugin vuex store or similar so a plugin can access global data
            this.$emit('genesRetrieved', genes);
        },
        genesChanged: function genesChanged(newValue, id) {
            this.$emit('genesChanged', newValue, this.id);
        },
        checkGenes: function checkGenes() {
            var vm = this;
            if (vm.prop_genes.length > 0) vm.$set(vm, 'genes', vm.prop_genes);else if (vm.genes.length < 1) vm.getGenes();
        },
        getGenes: function getGenes() {
            var vm = this;
            _axios2.default.get('https://civic.genome.wustl.edu/api/genes?count=300').then(function (response) {
                var genes = response.data.records.map(function (g) {
                    return g.variants.map(function (v) {
                        return { id: v.id, name: g.name + ' - ' + v.name };
                    });
                }).reduce(function (a, b) {
                    return a.concat(b);
                });
                vm.$set(vm, 'genes', genes);
                vm.genesRetrieved(genes);
            });
        }
    }
};

/***/ }),

/***/ 341:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _ScanLookup = __webpack_require__(654);

var _ScanLookup2 = _interopRequireDefault(_ScanLookup);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

module.exports = {
    name: 'SpecimenTrackingDashboard',
    components: {
        ScanLookup: _ScanLookup2.default
    },
    props: {
        organization: Object,
        user: Object
    },
    methods: {
        scanLookup: function scanLookup(action, value) {}
    }
}; //
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/***/ }),

/***/ 574:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(30)();
// imports


// module
exports.push([module.i, "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n", ""]);

// exports


/***/ }),

/***/ 575:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(30)();
// imports


// module
exports.push([module.i, "\n.datetime-picker input {\r\n  height: 4em !important;\n}\r\n", ""]);

// exports


/***/ }),

/***/ 576:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(30)();
// imports


// module
exports.push([module.i, "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\r\n/* Using the bootstrap style, but overriding the font to not draw in\r\n   the Glyphicons Halflings font as an additional requirement for sorting icons.\r\n\r\n   An alternative to the solution active below is to use the jquery style\r\n   which uses images, but the color on the images does not match adminlte.\r\n\r\n@import url('/static/js/plugins/datatables/jquery.dataTables.min.css');\r\n*/\ntable.dataTable thead .sorting:after, table.dataTable thead .sorting_asc:after, table.dataTable thead .sorting_desc:after {\r\n  font-family: 'FontAwesome';\n}\ntable.dataTable thead .sorting:after {\r\n  content: \"\\F0DC\";\n}\ntable.dataTable thead .sorting_asc:after {\r\n  content: \"\\F0DD\";\n}\ntable.dataTable thead .sorting_desc:after {\r\n  content: \"\\F0DE\";\n}\r\n", ""]);

// exports


/***/ }),

/***/ 577:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(30)();
// imports


// module
exports.push([module.i, "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n", ""]);

// exports


/***/ }),

/***/ 578:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(30)();
// imports


// module
exports.push([module.i, "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n", ""]);

// exports


/***/ }),

/***/ 579:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(30)();
// imports


// module
exports.push([module.i, "\ntable.nowrap th {\n    white-space: nowrap !important;\n}\ntable.nowrap td {\n    white-space: nowrap !important;\n}\ntable td {\n    vertical-align: top;\n}\n.dataTables_wrapper .row {\n    margin-top: 0px !important;\n}\n", ""]);

// exports


/***/ }),

/***/ 580:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(30)();
// imports


// module
exports.push([module.i, "\n.timeline-footer a.btn {\n  margin-right: 10px;\n}\n", ""]);

// exports


/***/ }),

/***/ 581:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(30)();
// imports


// module
exports.push([module.i, "\n.user-panel {\n    height: 4em;\n}\nhr.visible-xs-block {\n    width: 100%;\n    background-color: rgba(0, 0, 0, 0.17);\n    height: 1px;\n    border-color: transparent;\n}\n", ""]);

// exports


/***/ }),

/***/ 582:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(30)();
// imports


// module
exports.push([module.i, "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n", ""]);

// exports


/***/ }),

/***/ 584:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ 585:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__.p + "img/logo-2wgUBz5.png";

/***/ }),

/***/ 586:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__.p + "favicon.ico";

/***/ }),

/***/ 60:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


var _typeof = typeof Symbol === "function" && typeof Symbol.iterator === "symbol" ? function (obj) { return typeof obj; } : function (obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; };

var _vue = __webpack_require__(51);

var _vue2 = _interopRequireDefault(_vue);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var uuidV1 = __webpack_require__(78);

_vue2.default.mixin({
    methods: {

        getSpecimenTransports: function getSpecimenTransports(typeCode) {
            var type = this.organization.customData.specimenDefinitions.filter(function (s) {
                return s.code === typeCode;
            })[0];
            return type.transports;
        },

        getSpecimenAttributesBySection: function getSpecimenAttributesBySection(sectionName, specimenTypeCode) {
            var attr = new Array();
            var allAttr = this.organization.customData.specimenDefinitions.filter(function (s) {
                return s.code === specimenTypeCode;
            })[0].accessionAttributes; //.selectMany(d=> d.accessionAttributes);
            return allAttr.filter(function (a) {
                return a.section === sectionName;
            });
            //var uniqueSet = filter(new Set(allAttr), a => a.section === sectionName);
            //return Array.from(uniqueSet);
        },

        ///apply organization custom data to new and existing specimens (additive)
        setSpecimenAttributes: function setSpecimenAttributes(specimen) {
            if (specimen.attributesAreSet) return;

            var vueVm = this;
            var specAttributes = vueVm.organization.customData.specimenDefinitions.filter(function (s) {
                return s.code === specimen.type.code;
            })[0].accessionAttributes;

            var _iteratorNormalCompletion = true;
            var _didIteratorError = false;
            var _iteratorError = undefined;

            try {
                var _loop = function _loop() {
                    var attribute = _step.value;


                    if (typeof specimen.customData === "undefined") {
                        vueVm.$set(specimen, "customData", {});
                    }

                    if (specimen.customData === null) {
                        vueVm.$set(specimen, "customData", {});
                    }

                    if (typeof specimen.customData.attributes === "undefined") {
                        vueVm.$set(specimen.customData, "attributes", []);
                    }

                    if (typeof specimen.customData.attributes.find(function (a) {
                        return a.name === attribute.name;
                    }) === "undefined") {
                        if (attribute.type === 'multiple-large' || attribute.type === 'multiple-small' || attribute.type === 'civic-gene-api') specimen.customData.attributes.push({ name: attribute.name, value: [{ id: "", name: "" }] });else specimen.customData.attributes.push({ name: attribute.name, value: { id: "", name: "" } });
                    }

                    vueVm.$set(specimen, "attributesAreSet", true);
                };

                for (var _iterator = specAttributes[Symbol.iterator](), _step; !(_iteratorNormalCompletion = (_step = _iterator.next()).done); _iteratorNormalCompletion = true) {
                    _loop();
                }
            } catch (err) {
                _didIteratorError = true;
                _iteratorError = err;
            } finally {
                try {
                    if (!_iteratorNormalCompletion && _iterator.return) {
                        _iterator.return();
                    }
                } finally {
                    if (_didIteratorError) {
                        throw _iteratorError;
                    }
                }
            }

            this.$nextTick(function () {
                this.toolTips();
            });
        },

        updateSpecimenAttributeFromText: function updateSpecimenAttributeFromText(event) {
            var idParams = event.target.id.split('_');
            var specimenGuid = idParams[0];
            var attributeName = idParams[1];
            var attributeType = idParams[2];
            this.updateSpecimenAttribute(this.currentSpecimen, attributeName, event.target.value, false);
        },

        updateSpecimenAttributeFromMultiSelect: function updateSpecimenAttributeFromMultiSelect(value, id) {
            var idParams = id.split('_');
            var specimenGuid = idParams[0];
            var attributeName = idParams[1];
            var attributeType = idParams[2];

            var multiple = attributeType === 'multiple-large' || attributeType === 'multiple-small' || attributeType === 'civic-gene-api';
            var specimen = this.currentSpecimen; //this.specimens.find(function (s) { return s.guid === specimenGuid });

            this.updateSpecimenAttribute(specimen, attributeName, value, multiple);
        },

        updateSpecimenAttribute: function updateSpecimenAttribute(specimen, attributeName, attributeValue, singleToMultiple) {
            var attr = specimen.customData.attributes.find(function (a) {
                return a.name === attributeName;
            });
            if (singleToMultiple) {
                //var currentSet = new Set(Array.isArray(attr.value) ? attr.value : [].concat(attr.value));
                var newSet = new Set(Array.isArray(attributeValue) ? attributeValue : [].concat(attributeValue));
                //currentSet.forEach(function(v){
                //    var duplicateItem = Array.from(newSet).find(function(v1){return v1.id === v.id});
                //    if(typeof(duplicateItem) !== 'undefined')
                //        newSet.delete(duplicateItem);
                //});
                //attributeValue = Array.from(new Set([...currentSet, ...newSet]));
                attributeValue = Array.from(newSet);
            }
            this.$set(attr, "value", attributeValue); //being safe

            this.changed();
        },

        currentSpecimenAttributeValue: function currentSpecimenAttributeValue(specimen, attributeName, expectsSingle) {

            var originallySingle = false;
            var value = null;

            if (typeof specimen.customData.attributes !== 'undefined') {
                var attributeOnSpecimen = specimen.customData.attributes.find(function (a) {
                    return a.name === attributeName;
                });
                if (typeof attributeOnSpecimen !== 'undefined' && typeof attributeOnSpecimen.value !== 'undefined') value = attributeOnSpecimen.value;
            }
            if (!Array.isArray(value)) {
                originallySingle = true;
                value = [value];
            }
            var newVal = [];
            value.forEach(function (val) {
                if (val !== null && (typeof val === 'undefined' ? 'undefined' : _typeof(val)) === 'object') {
                    newVal.push(val);
                }
            });
            if ((expectsSingle || originallySingle) && newVal.length > 0) newVal = newVal[0];else if (newVal.length === 1 && newVal[0].id === '') //the default value, which isn't needed for multi-select types
                newVal = [];

            return newVal;
        }
    },
    computed: {
        organizationSpecimenTypes: function organizationSpecimenTypes() {
            return Array.from(new Set(this.organization.customData.specimenDefinitions.map(function (spec) {
                return { type: spec.type, code: spec.code };
            }))); //set should de-dup .. maybe
        },
        organizationUsesCases: function organizationUsesCases() {
            return false; //todo
        },
        organizationUsesSpecimens: function organizationUsesSpecimens() {
            return true; //todo
        }
    }
});

/***/ }),

/***/ 631:
/***/ (function(module, exports, __webpack_require__) {


/* styles */
__webpack_require__(692)

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(326),
  /* template */
  __webpack_require__(680),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\404.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] 404.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-d66b7486", Component.options)
  } else {
    hotAPI.reload("data-v-d66b7486", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 632:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(327),
  /* template */
  __webpack_require__(674),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\App.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] App.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-96021bf4", Component.options)
  } else {
    hotAPI.reload("data-v-96021bf4", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 633:
/***/ (function(module, exports, __webpack_require__) {


/* styles */
__webpack_require__(684)

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(328),
  /* template */
  __webpack_require__(657),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\Mailbox.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] Mailbox.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-1af05ece", Component.options)
  } else {
    hotAPI.reload("data-v-1af05ece", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 634:
/***/ (function(module, exports, __webpack_require__) {


/* styles */
__webpack_require__(691)

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(329),
  /* template */
  __webpack_require__(677),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\Main.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] Main.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-b139a0b8", Component.options)
  } else {
    hotAPI.reload("data-v-b139a0b8", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 635:
/***/ (function(module, exports, __webpack_require__) {


/* styles */
__webpack_require__(687)

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(300),
  /* template */
  __webpack_require__(665),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\accessioning\\Accessioning.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] Accessioning.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-4da0d858", Component.options)
  } else {
    hotAPI.reload("data-v-4da0d858", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 636:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(302),
  /* template */
  __webpack_require__(673),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\accessioning\\Patient.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] Patient.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-91458d42", Component.options)
  } else {
    hotAPI.reload("data-v-91458d42", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 637:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(304),
  /* template */
  __webpack_require__(667),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\accessioning\\Specimens.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] Specimens.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-5d660145", Component.options)
  } else {
    hotAPI.reload("data-v-5d660145", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 638:
/***/ (function(module, exports, __webpack_require__) {


/* styles */
__webpack_require__(688)

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(330),
  /* template */
  __webpack_require__(668),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\admin\\ClientAdmin.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] ClientAdmin.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-6a867329", Component.options)
  } else {
    hotAPI.reload("data-v-6a867329", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 639:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(331),
  /* template */
  __webpack_require__(660),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\admin\\Organization.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] Organization.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-34769b9e", Component.options)
  } else {
    hotAPI.reload("data-v-34769b9e", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 640:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(332),
  /* template */
  __webpack_require__(661),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\dash\\DashboardContainer.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] DashboardContainer.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-3701550f", Component.options)
  } else {
    hotAPI.reload("data-v-3701550f", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 641:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(306),
  /* template */
  __webpack_require__(659),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\entities\\AccessionInfo.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] AccessionInfo.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-1f1d12e2", Component.options)
  } else {
    hotAPI.reload("data-v-1f1d12e2", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 642:
/***/ (function(module, exports, __webpack_require__) {


/* styles */
__webpack_require__(689)

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(308),
  /* template */
  __webpack_require__(671),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\list\\Worklist.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] Worklist.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-765e9c36", Component.options)
  } else {
    hotAPI.reload("data-v-765e9c36", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 643:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(310),
  /* template */
  __webpack_require__(670),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\list\\WorklistCaseDetail.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] WorklistCaseDetail.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-710624e6", Component.options)
  } else {
    hotAPI.reload("data-v-710624e6", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 644:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(312),
  /* template */
  __webpack_require__(666),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\list\\WorklistSpecimenDetail.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] WorklistSpecimenDetail.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-54eb603e", Component.options)
  } else {
    hotAPI.reload("data-v-54eb603e", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 645:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(314),
  /* template */
  __webpack_require__(676),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\list\\WorklistSpecimens.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] WorklistSpecimens.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-9c300a94", Component.options)
  } else {
    hotAPI.reload("data-v-9c300a94", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 646:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(333),
  /* template */
  __webpack_require__(681),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\main\\AppFooter.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] AppFooter.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-f68dcc9e", Component.options)
  } else {
    hotAPI.reload("data-v-f68dcc9e", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 647:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(334),
  /* template */
  __webpack_require__(679),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\main\\Navbar.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] Navbar.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-cf978c6a", Component.options)
  } else {
    hotAPI.reload("data-v-cf978c6a", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 648:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(335),
  /* template */
  __webpack_require__(678),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\main\\SecondarySidebar.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] SecondarySidebar.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-c4224d7a", Component.options)
  } else {
    hotAPI.reload("data-v-c4224d7a", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 649:
/***/ (function(module, exports, __webpack_require__) {


/* styles */
__webpack_require__(685)

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(336),
  /* template */
  __webpack_require__(658),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\main\\Setting.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] Setting.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-1ec4ebb6", Component.options)
  } else {
    hotAPI.reload("data-v-1ec4ebb6", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 650:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(337),
  /* template */
  __webpack_require__(662),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\main\\Sidebar.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] Sidebar.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-4129bd9e", Component.options)
  } else {
    hotAPI.reload("data-v-4129bd9e", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 651:
/***/ (function(module, exports, __webpack_require__) {


/* styles */
__webpack_require__(686)

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(338),
  /* template */
  __webpack_require__(664),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\main\\Tables.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] Tables.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-4c3529a0", Component.options)
  } else {
    hotAPI.reload("data-v-4c3529a0", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 652:
/***/ (function(module, exports, __webpack_require__) {


/* styles */
__webpack_require__(690)

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(339),
  /* template */
  __webpack_require__(672),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\main\\Tasks.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] Tasks.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-7c6f53a3", Component.options)
  } else {
    hotAPI.reload("data-v-7c6f53a3", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 653:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(340),
  /* template */
  __webpack_require__(663),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\plugins\\externaldata\\CivicGeneSelection.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] CivicGeneSelection.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-49409e3d", Component.options)
  } else {
    hotAPI.reload("data-v-49409e3d", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 654:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(315),
  /* template */
  __webpack_require__(675),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\tools\\ScanLookup.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] ScanLookup.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-96376114", Component.options)
  } else {
    hotAPI.reload("data-v-96376114", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 655:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(6)(
  /* script */
  __webpack_require__(341),
  /* template */
  __webpack_require__(669),
  /* scopeId */
  null,
  /* cssModules */
  null
)
Component.options.__file = "C:\\source\\clinicacloudplatform\\src\\clinicacloudplatform_gui\\VueApp\\components\\tracking\\SpecimenTrackingDashboard.vue"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key !== "__esModule"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] SpecimenTrackingDashboard.vue: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-6f9f3a88", Component.options)
  } else {
    hotAPI.reload("data-v-6f9f3a88", Component.options)
  }
})()}

module.exports = Component.exports


/***/ }),

/***/ 657:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('section', {
    staticClass: "content"
  }, [_c('div', {
    staticClass: "center-block"
  }, [_c('div', {
    staticClass: "col-auto"
  }, [(_vm.user.hasMessages) ? _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n                    Mailbox " + _vm._s(_vm.user.fullName) + "\n                ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('table', {
    staticClass: "table table-striped"
  }, [_vm._m(0), _vm._v(" "), _c('tbody', _vm._l((_vm.user.customData.messages), function(message) {
    return _c('tr', [_c('td', [_vm._v(_vm._s(_vm._f("prettyDate")(message.timeStamp)))]), _vm._v(" "), _c('td', [_vm._v(_vm._s(message.from))]), _vm._v(" "), _c('td', [_vm._v(_vm._s(message.subject))]), _vm._v(" "), _c('td', [_vm._v(_vm._s(message.text))])])
  }))])])]) : _c('div', {
    staticClass: "card card-inverse card-info text-center"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n                    No messages.\n                    "), _c('footer', [_vm._v("TODO:  Figure out why this only shows messages when opened by router link from main.  Hint: use vue tools in chrome, vuex shows an uncommitted getUser....")])])])])])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('thead', [_c('tr', [_c('th', [_vm._v("Date")]), _vm._v(" "), _c('th', [_vm._v("From")]), _vm._v(" "), _c('th', [_vm._v("Subject")]), _vm._v(" "), _c('th', [_vm._v("Message")])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-1af05ece", module.exports)
  }
}

/***/ }),

/***/ 658:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', [_c('h1', {
    staticClass: "text-center"
  }, [_vm._v("Settings")]), _vm._v(" "), _c('section', {
    staticClass: "content"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "card box-info"
  }, [_vm._m(0), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_vm._m(1), _vm._v(" "), _c('datepicker', {
    attrs: {
      "readonly": true,
      "format": "MMM/D/YYYY",
      "id": "dateInput",
      "width": "100%"
    }
  })], 1), _vm._v(" "), _c('br'), _vm._v(" "), _c('br'), _vm._v(" "), _vm._m(2), _vm._v(" "), _c('br'), _vm._v(" "), _vm._m(3), _vm._v(" "), _c('br'), _vm._v(" "), _c('h4', [_vm._v("With icons")]), _vm._v(" "), _vm._m(4), _vm._v(" "), _c('br'), _vm._v(" "), _vm._m(5), _vm._v(" "), _c('br'), _vm._v(" "), _c('h4', [_vm._v("With border indicator")]), _vm._v(" "), _vm._m(6), _vm._v(" "), _c('br'), _vm._v(" "), _vm._m(7), _vm._v(" "), _c('h4', [_vm._v("Select Options")]), _vm._v(" "), _vm._m(8), _vm._v(" "), _c('br'), _vm._v(" "), _vm._m(9)])])])])])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-header with-border"
  }, [_c('h3', {
    staticClass: "card-title"
  }, [_vm._v("Inputs")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-calendar"
  })])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_vm._v("@")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "placeholder": "Username",
      "type": "text"
    }
  })])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_vm._v("$")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-addon"
  }, [_vm._v(".00")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-envelope"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "placeholder": "Email",
      "type": "email"
    }
  })])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "input-group"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-check"
  })])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "form-group has-success"
  }, [_c('label', {
    staticClass: "control-label",
    attrs: {
      "for": "inputSuccess"
    }
  }, [_c('i', {
    staticClass: "fa fa-check"
  }), _vm._v(" Input with success")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "id": "inputSuccess",
      "placeholder": "Enter ...",
      "type": "text"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "help-block"
  }, [_vm._v("Help block with success")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "form-group has-error"
  }, [_c('label', {
    staticClass: "control-label",
    attrs: {
      "for": "inputError"
    }
  }, [_c('i', {
    staticClass: "fa fa-times-circle-o"
  }), _vm._v(" Input with error")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "id": "inputError",
      "placeholder": "Enter ...",
      "type": "text"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "help-block"
  }, [_vm._v("Help block with error")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "form-group"
  }, [_c('label', [_vm._v("Select")]), _vm._v(" "), _c('select', {
    staticClass: "form-control"
  }, [_c('option', [_vm._v("option 1")]), _vm._v(" "), _c('option', [_vm._v("option 2")]), _vm._v(" "), _c('option', [_vm._v("option 3")]), _vm._v(" "), _c('option', [_vm._v("option 4")]), _vm._v(" "), _c('option', [_vm._v("option 5")])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "form-group"
  }, [_c('label', [_vm._v("Select Multiple")]), _vm._v(" "), _c('select', {
    staticClass: "form-control",
    attrs: {
      "multiple": ""
    }
  }, [_c('option', [_vm._v("option 1")]), _vm._v(" "), _c('option', [_vm._v("option 2")]), _vm._v(" "), _c('option', [_vm._v("option 3")]), _vm._v(" "), _c('option', [_vm._v("option 4")]), _vm._v(" "), _c('option', [_vm._v("option 5")])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-1ec4ebb6", module.exports)
  }
}

/***/ }),

/***/ 659:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "container-fluid pl-0 pr-0"
  }, [_c('div', {
    staticClass: "card card-accent-primary card-compact"
  }, [_c('div', {
    staticClass: "card-header card-compact"
  }, [(_vm.$route.name !== 'Specimen Catalog') ? _c('router-link', {
    staticClass: "page-link bg-gray-light font-weight-bold",
    attrs: {
      "to": {
        name: 'Edit Accession',
        params: {
          id: _vm.accession.id,
          orgNameKey: _vm.organization.nameKey
        }
      }
    }
  }, [_c('i', {
    staticClass: "fa fa-edit"
  }), _vm._v(" Edit "), _c('span', {
    staticClass: "accessionLabel"
  }, [_vm._v("Accession")]), _vm._v(" # " + _vm._s(_vm.accession.id) + " - " + _vm._s(_vm._f("localeDate")(_vm.accession.createdDate)) + "\n            ")]) : _c('div', {
    staticClass: "font-weight-bold"
  }, [_vm._v("\n                Samples Received on " + _vm._s(_vm._f("localeDate")(_vm.accession.createdDate)) + "\n            ")])], 1), _vm._v(" "), _c('div', {
    staticClass: "card-block card-compact"
  }, [_c('div', {
    staticClass: "row m-0"
  }, [_c('div', {
    staticClass: "col-sm-6 m-0 p-0"
  }, [_c('div', {
    staticClass: "card card-compact card-no-outer-border"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("General")]), _vm._v(" "), _c('div', {
    staticClass: "card-block wrap-unset"
  }, [_c('div', {
    staticClass: "row m-0"
  }, [_c('div', {
    staticClass: "col-sm-auto mr-1"
  }, [_c('label', {
    staticClass: "label-black",
    attrs: {
      "for": 'accClient' + _vm.accession.id + _vm.accession.clientId
    }
  }, [_vm._m(0), _vm._v(":\n                                    ")])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-auto",
    attrs: {
      "id": 'accClient' + _vm.accession.id + _vm.accession.clientId
    }
  }, [_c('div', {
    staticClass: "m-0 p-0"
  }, [_vm._v("\n                                        " + _vm._s(_vm.lookup('client', _vm.accession.clientId, this.labs).name) + "\n                                    ")])])]), _vm._v(" "), _c('div', {
    staticClass: "row m-0"
  }, [_c('div', {
    staticClass: "col-sm-auto mr-1"
  }, [(_vm.$route.name !== 'Specimen Catalog') ? _c('label', {
    staticClass: "label-black",
    attrs: {
      "for": 'accLab' + _vm.accession.id + _vm.accession.orderingLabId
    }
  }, [_c('strong', [_vm._v("Received At")]), _vm._v(":\n                                    ")]) : _c('label', {
    staticClass: "label-black",
    attrs: {
      "for": 'accLab' + _vm.accession.id + _vm.accession.orderingLabId
    }
  }, [_c('strong', [_vm._v("Location")]), _vm._v(":\n                                    ")])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-auto",
    attrs: {
      "id": 'accLab' + _vm.accession.id + _vm.accession.orderingLabId
    }
  }, [_c('div', {
    staticClass: "m-0 p-0"
  }, [_vm._v("\n                                        " + _vm._s(_vm.lookup('lab', _vm.accession.orderingLabId, this.labs).name) + "\n                                        "), (_vm.$route.name === 'Specimen Catalog') ? _c('small', [_vm._v("(San Diego, CA)")]) : _vm._e()])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 m-0 p-0"
  }, [_c('div', {
    staticClass: "card card-compact card-no-outer-border"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Specimens/Cases")]), _vm._v(" "), _c('div', {
    staticClass: "card-block wrap-unset"
  }, [_c('div', {
    staticClass: "row m-0"
  }, [_c('div', {
    staticClass: "col-sm-auto mr-1"
  }, [_c('label', {
    staticClass: "label-black",
    attrs: {
      "for": 'accSpecimenCount' + _vm.accession.id
    }
  }, [_vm._m(1), _vm._v(":\n                                    ")])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-auto",
    attrs: {
      "id": 'accSpecimenCount' + _vm.accession.id
    }
  }, [_c('div', {
    staticClass: "m-0 p-0"
  }, [_vm._v("\n                                        " + _vm._s(_vm.accession.specimens.length) + "\n                                    ")])])]), _vm._v(" "), _c('div', {
    staticClass: "row m-0"
  }, [_c('div', {
    staticClass: "col-sm-auto mr-1"
  }, [_c('label', {
    staticClass: "label-black",
    attrs: {
      "for": 'accCaseCount' + _vm.accession.id
    }
  }, [_vm._m(2), _vm._v(":\n                                    ")])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-auto",
    attrs: {
      "id": 'accCaseCount' + _vm.accession.id
    }
  }, [_c('div', {
    staticClass: "m-0 p-0"
  }, [_vm._v("\n                                        N/A\n                                    ")])])])])])])])])])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('strong', [_c('span', {
    staticClass: "clientLabel"
  }, [_vm._v("Institution")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('strong', [_c('span', {
    staticClass: "specimensLabel"
  }, [_vm._v("Specimens")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('strong', [_c('span', {
    staticClass: "casesLabel"
  }, [_vm._v("Cases")])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-1f1d12e2", module.exports)
  }
}

/***/ }),

/***/ 660:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n        " + _vm._s(_vm.user.fullName) + " - " + _vm._s(_vm.organization.name) + "\n        "), _vm._m(0)]), _vm._v(" "), _vm._m(1)])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-actions"
  }, [_c('a', {
    attrs: {
      "href": "https://github.com/digitalBush/jquery.maskedinput"
    }
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("docs")])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-block"
  }, [_c('fieldset', {
    staticClass: "form-group"
  }, [_c('label', [_vm._v("Multiple Select / Tags")]), _vm._v(" "), _c('select', {
    staticClass: "form-control select2-multiple",
    attrs: {
      "id": "select2",
      "multiple": ""
    }
  }, [_c('option', [_vm._v("Option 1")]), _vm._v(" "), _c('option', {
    attrs: {
      "selected": ""
    }
  }, [_vm._v("Option 2")]), _vm._v(" "), _c('option', [_vm._v("Option 3")]), _vm._v(" "), _c('option', [_vm._v("Option 4")]), _vm._v(" "), _c('option', [_vm._v("Option 5")])]), _vm._v(" "), _c('input', {
    staticClass: "demo",
    attrs: {
      "id": "demo",
      "name": "demo"
    }
  })])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-34769b9e", module.exports)
  }
}

/***/ }),

/***/ 661:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('section', {
    staticClass: "content"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('h2', [_vm._v("Coming Soon!")])])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-3701550f", module.exports)
  }
}

/***/ }),

/***/ 662:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "sidebar"
  }, [_c('nav', {
    staticClass: "sidebar-nav open"
  }, [_vm._m(0), _vm._v(" "), _vm._l((this.$router.options.routes), function(route) {
    return _c('div', {
      staticClass: "p-0 m-0"
    }, [_c('ul', {
      staticClass: "nav search-nav"
    }, [_c('li', {
      staticClass: "nav-title"
    }, [_c('a', [_vm._v(_vm._s(route.name))])]), _vm._v(" "), _vm._l((route.children), function(childRoute) {
      return (childRoute.meta == null || childRoute.meta.showInNavMenu == null || childRoute.meta.showInNavMenu == true) ? _c('li', {
        staticClass: "nav-item"
      }, [_c('router-link', {
        staticClass: "nav-link",
        attrs: {
          "tag": "a",
          "to": route.path + childRoute.path
        }
      }, [_c('i', {
        class: childRoute.meta == null || childRoute.meta.iconClass == null ? _vm.defaultRouteIconClasses : childRoute.meta.iconClass
      }), _vm._v("\n                            " + _vm._s(childRoute.name) + "\n                        ")])], 1) : _vm._e()
    })], 2)])
  })], 2)])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('form', [_c('h5', [_vm._v("Main Menu")]), _vm._v(" "), _c('div', {
    staticClass: "form-group p-h mb-0 ml-h mr-h"
  }, [_c('input', {
    staticClass: "search form-control",
    attrs: {
      "type": "text",
      "name": "search",
      "id": "search",
      "data-toggle": "hideseek",
      "placeholder": "Search Menu",
      "data-list": ".search-nav"
    }
  })])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-4129bd9e", module.exports)
  }
}

/***/ }),

/***/ 663:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('multiselect', {
    attrs: {
      "id": "geneSelect",
      "track-by": "id",
      "label": "name",
      "placeholder": "Select one or more",
      "options": _vm.genes,
      "searchable": true,
      "multiple": true,
      "allow-empty": true,
      "value": _vm.prop_value
    },
    on: {
      "changed": _vm.genesChanged
    }
  })
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-49409e3d", module.exports)
  }
}

/***/ }),

/***/ 664:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('section', {
    staticClass: "content"
  }, [_vm._m(0), _vm._v(" "), _c('div', {
    staticClass: "center-block"
  }, [_c('div', {
    staticClass: "col-lg-12"
  }, [_c('div', {
    staticClass: "card"
  }, [_vm._m(1), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "dataTables_wrapper form-inline dt-bootstrap",
    attrs: {
      "id": "example1_wrapper"
    }
  }, [_vm._m(2), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('table', {
    staticClass: "table table-bordered table-striped dataTable",
    attrs: {
      "aria-describedby": "example1_info",
      "role": "grid",
      "id": "example1"
    }
  }, [_vm._m(3), _vm._v(" "), _vm._m(4), _vm._v(" "), _c('tfoot', [_c('tr', [_c('th', {
    attrs: {
      "colspan": "1",
      "rowspan": "1"
    }
  }, [_vm._v("Rendering engine")]), _vm._v(" "), _c('th', {
    attrs: {
      "colspan": "1",
      "rowspan": "1"
    }
  }, [_vm._v("Browser")]), _vm._v(" "), _c('th', {
    attrs: {
      "colspan": "1",
      "rowspan": "1"
    }
  }, [_vm._v("Platform(s)")]), _vm._v(" "), _c('th', {
    attrs: {
      "colspan": "1",
      "rowspan": "1"
    }
  }, [_vm._v("Engine version")]), _vm._v(" "), _c('th', {
    attrs: {
      "colspan": "1",
      "rowspan": "1"
    }
  }, [_vm._v("CSS grade")])])])], 1)])])])])])])])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "center-block"
  }, [_c('div', {
    staticClass: "col-lg-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Striped Full Width Table\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('table', {
    staticClass: "table table-striped"
  }, [_c('tbody', [_c('tr', [_c('th', {
    staticStyle: {
      "width": "10px"
    }
  }, [_vm._v("#")]), _vm._v(" "), _c('th', [_vm._v("Task")]), _vm._v(" "), _c('th', [_vm._v("Progress")]), _vm._v(" "), _c('th', {
    staticStyle: {
      "width": "40px"
    }
  }, [_vm._v("Label")])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("1.")]), _vm._v(" "), _c('td', [_vm._v("Update software")]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar progress-bar-danger",
    staticStyle: {
      "width": "55%"
    }
  })])]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge bg-red"
  }, [_vm._v("55%")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("2.")]), _vm._v(" "), _c('td', [_vm._v("Clean database")]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar progress-bar-yellow",
    staticStyle: {
      "width": "70%"
    }
  })])]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge bg-yellow"
  }, [_vm._v("70%")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("3.")]), _vm._v(" "), _c('td', [_vm._v("Cron job running")]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "progress progress-xs progress-striped active"
  }, [_c('div', {
    staticClass: "progress-bar progress-bar-primary",
    staticStyle: {
      "width": "30%"
    }
  })])]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge bg-light-blue"
  }, [_vm._v("30%")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("4.")]), _vm._v(" "), _c('td', [_vm._v("Fix and squish bugs")]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "progress progress-xs progress-striped active"
  }, [_c('div', {
    staticClass: "progress-bar progress-bar-success",
    staticStyle: {
      "width": "90%"
    }
  })])]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge bg-green"
  }, [_vm._v("90%")])])])])])])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-header"
  }, [_c('div', {
    staticClass: "card-title"
  }, [_vm._v("Data Table With Full Features")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "dataTables_length",
    attrs: {
      "id": "example1_length"
    }
  })])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('thead', [_c('tr', {
    attrs: {
      "role": "row"
    }
  }, [_c('th', {
    staticClass: "sorting_asc",
    staticStyle: {
      "width": "167px"
    },
    attrs: {
      "aria-label": "Rendering engine: activate to sort column descending",
      "aria-sort": "ascending",
      "colspan": "1",
      "rowspan": "1",
      "aria-controls": "example1",
      "tabindex": "0"
    }
  }, [_vm._v("Rendering engine")]), _vm._v(" "), _c('th', {
    staticClass: "sorting",
    staticStyle: {
      "width": "207px"
    },
    attrs: {
      "aria-label": "Browser: activate to sort column ascending",
      "colspan": "1",
      "rowspan": "1",
      "aria-controls": "example1",
      "tabindex": "0"
    }
  }, [_vm._v("Browser")]), _vm._v(" "), _c('th', {
    staticClass: "sorting",
    staticStyle: {
      "width": "182px"
    },
    attrs: {
      "aria-label": "Platform(s): activate to sort column ascending",
      "colspan": "1",
      "rowspan": "1",
      "aria-controls": "example1",
      "tabindex": "0"
    }
  }, [_vm._v("Platform(s)")]), _vm._v(" "), _c('th', {
    staticClass: "sorting",
    staticStyle: {
      "width": "142px"
    },
    attrs: {
      "aria-label": "Engine version: activate to sort column ascending",
      "colspan": "1",
      "rowspan": "1",
      "aria-controls": "example1",
      "tabindex": "0"
    }
  }, [_vm._v("Engine version")]), _vm._v(" "), _c('th', {
    staticClass: "sorting",
    staticStyle: {
      "width": "101px"
    },
    attrs: {
      "aria-label": "CSS grade: activate to sort column ascending",
      "colspan": "1",
      "rowspan": "1",
      "aria-controls": "example1",
      "tabindex": "0"
    }
  }, [_vm._v("CSS grade")])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('tbody', [_c('tr', {
    staticClass: "even",
    attrs: {
      "role": "row"
    }
  }, [_c('td', {
    staticClass: "sorting_1"
  }, [_vm._v("Blink")]), _vm._v(" "), _c('td', [_vm._v("Iridium  54.0")]), _vm._v(" "), _c('td', [_vm._v("GNU/Linux")]), _vm._v(" "), _c('td', [_vm._v("54")]), _vm._v(" "), _c('td', [_vm._v("A")])]), _vm._v(" "), _c('tr', {
    staticClass: "odd",
    attrs: {
      "role": "row"
    }
  }, [_c('td', {
    staticClass: "sorting_1"
  }, [_vm._v("Gecko")]), _vm._v(" "), _c('td', [_vm._v("Firefox 1.0")]), _vm._v(" "), _c('td', [_vm._v("Win 98+ / OSX.2+")]), _vm._v(" "), _c('td', [_vm._v("1.7")]), _vm._v(" "), _c('td', [_vm._v("A")])]), _vm._v(" "), _c('tr', {
    staticClass: "even",
    attrs: {
      "role": "row"
    }
  }, [_c('td', {
    staticClass: "sorting_1"
  }, [_vm._v("Gecko")]), _vm._v(" "), _c('td', [_vm._v("Firefox 1.5")]), _vm._v(" "), _c('td', [_vm._v("Win 98+ / OSX.2+")]), _vm._v(" "), _c('td', [_vm._v("1.8")]), _vm._v(" "), _c('td', [_vm._v("A")])]), _vm._v(" "), _c('tr', {
    staticClass: "odd",
    attrs: {
      "role": "row"
    }
  }, [_c('td', {
    staticClass: "sorting_1"
  }, [_vm._v("Gecko")]), _vm._v(" "), _c('td', [_vm._v("Firefox 2.0")]), _vm._v(" "), _c('td', [_vm._v("Win 98+ / OSX.2+")]), _vm._v(" "), _c('td', [_vm._v("1.8")]), _vm._v(" "), _c('td', [_vm._v("A")])]), _vm._v(" "), _c('tr', {
    staticClass: "even",
    attrs: {
      "role": "row"
    }
  }, [_c('td', {
    staticClass: "sorting_1"
  }, [_vm._v("Gecko")]), _vm._v(" "), _c('td', [_vm._v("Firefox 3.0")]), _vm._v(" "), _c('td', [_vm._v("Win 2k+ / OSX.3+")]), _vm._v(" "), _c('td', [_vm._v("1.9")]), _vm._v(" "), _c('td', [_vm._v("A")])]), _vm._v(" "), _c('tr', {
    staticClass: "odd",
    attrs: {
      "role": "row"
    }
  }, [_c('td', {
    staticClass: "sorting_1"
  }, [_vm._v("Gecko")]), _vm._v(" "), _c('td', [_vm._v("Camino 1.0")]), _vm._v(" "), _c('td', [_vm._v("OSX.2+")]), _vm._v(" "), _c('td', [_vm._v("1.8")]), _vm._v(" "), _c('td', [_vm._v("A")])]), _vm._v(" "), _c('tr', {
    staticClass: "even",
    attrs: {
      "role": "row"
    }
  }, [_c('td', {
    staticClass: "sorting_1"
  }, [_vm._v("Gecko")]), _vm._v(" "), _c('td', [_vm._v("Camino 1.5")]), _vm._v(" "), _c('td', [_vm._v("OSX.3+")]), _vm._v(" "), _c('td', [_vm._v("1.8")]), _vm._v(" "), _c('td', [_vm._v("A")])]), _vm._v(" "), _c('tr', {
    staticClass: "odd",
    attrs: {
      "role": "row"
    }
  }, [_c('td', {
    staticClass: "sorting_1"
  }, [_vm._v("Gecko")]), _vm._v(" "), _c('td', [_vm._v("Netscape 7.2")]), _vm._v(" "), _c('td', [_vm._v("Win 95+ / Mac OS 8.6-9.2")]), _vm._v(" "), _c('td', [_vm._v("1.7")]), _vm._v(" "), _c('td', [_vm._v("A")])]), _vm._v(" "), _c('tr', {
    staticClass: "even",
    attrs: {
      "role": "row"
    }
  }, [_c('td', {
    staticClass: "sorting_1"
  }, [_vm._v("Gecko")]), _vm._v(" "), _c('td', [_vm._v("Netscape Browser 8")]), _vm._v(" "), _c('td', [_vm._v("Win 98SE+")]), _vm._v(" "), _c('td', [_vm._v("1.7")]), _vm._v(" "), _c('td', [_vm._v("A")])]), _vm._v(" "), _c('tr', {
    staticClass: "odd",
    attrs: {
      "role": "row"
    }
  }, [_c('td', {
    staticClass: "sorting_1"
  }, [_vm._v("Gecko")]), _vm._v(" "), _c('td', [_vm._v("Netscape Navigator 9")]), _vm._v(" "), _c('td', [_vm._v("Win 98+ / OSX.2+")]), _vm._v(" "), _c('td', [_vm._v("1.8")]), _vm._v(" "), _c('td', [_vm._v("A")])]), _vm._v(" "), _c('tr', {
    staticClass: "even",
    attrs: {
      "role": "row"
    }
  }, [_c('td', {
    staticClass: "sorting_1"
  }, [_vm._v("Gecko")]), _vm._v(" "), _c('td', [_vm._v("Mozilla 1.0")]), _vm._v(" "), _c('td', [_vm._v("Win 95+ / OSX.1+")]), _vm._v(" "), _c('td', [_vm._v("1")]), _vm._v(" "), _c('td', [_vm._v("A")])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-4c3529a0", module.exports)
  }
}

/***/ }),

/***/ 665:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "container-fluid p-lg-1 p-md-0 p-sm-0",
    attrs: {
      "id": "accessioningMain"
    }
  }, [_c('div', {
    staticClass: "modal",
    attrs: {
      "id": "loadingModal",
      "tabindex": "-1",
      "role": "dialog",
      "aria-labelledby": "myModalLabel",
      "aria-hidden": "true"
    }
  }, [_c('div', {
    staticClass: "modal-dialog modal-info",
    attrs: {
      "role": "document"
    }
  }, [_c('div', {
    staticClass: "modal-content"
  }, [_c('div', {
    staticClass: "modal-header"
  }, [_vm._v("\n                    Stand By\n                ")]), _vm._v(" "), _c('div', {
    staticClass: "modal-body text-center"
  }, [_c('h4', [_c('i', {
    staticClass: "fa fa-spinner fa-spin"
  }), _vm._v(" " + _vm._s(_vm.accessionState.currentAction) + "\n                        "), _c('span', {
    staticClass: "accessionLabel"
  }, [_vm._v("Accession")]), _vm._v(" "), (_vm.accessionState.currentAction != 'New') ? _c('span', [_vm._v(" ID " + _vm._s(_vm.$route.params.id))]) : _vm._e()])]), _vm._v(" "), _c('div', {
    staticClass: "modal-footer"
  })])])]), _vm._v(" "), (_vm.accessionState.loaded) ? _c('div', [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-xl-2 col-sm-3"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('div', {
    staticClass: "card card-inverse card-primary"
  }, [_c('div', {
    staticClass: "card-block"
  }, [(_vm.accessionState.isNew) ? _c('div', {
    staticClass: "row"
  }, [_vm._m(0)]) : _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('i', {
    staticClass: "icon-chemistry font-2xl mr-1 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "text-uppercase font-weight-bold font-xs"
  }, [_c('span', {
    staticClass: "accessionLabel"
  }, [_vm._v("Accession")]), _vm._v(" ID " + _vm._s(_vm.accessionState.accession.id))]), _vm._v("\n                                        " + _vm._s(_vm._f("prettyDate")(_vm.accessionState.accession.createdDate)) + "\n                                    ")])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('div', {
    staticClass: "dropdown w-100 mt-1"
  }, [_c('button', {
    staticClass: "btn btn-info dropdown-toggle w-100",
    attrs: {
      "enabled": _vm.validateSave(),
      "type": "button",
      "id": "saveAccessionDropdown",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('i', {
    staticClass: "fa fa-save font-2xl float-left"
  }), _vm._v("\n                                                Save\n                                            ")]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right",
    attrs: {
      "aria-labelledby": "saveAccessionDropdown"
    }
  }, [_c('div', {
    staticClass: "dropdown-item-info",
    on: {
      "click": _vm.saveAccession
    }
  }, [_vm._v("Save and Launch")]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-item-info",
    on: {
      "click": _vm.saveAccession
    }
  }, [_vm._v("Save and Hold")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('div', {
    staticClass: "dropdown w-100 mt-1"
  }, [_vm._m(1), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right",
    attrs: {
      "aria-labelledby": "printDropdown"
    }
  }, [_c('div', {
    staticClass: "dropdown-item-info",
    on: {
      "click": _vm.printAccession
    }
  }, [_vm._v("Print "), _c('span', {
    staticClass: "accessionLabel"
  }, [_vm._v("Accession")])]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-item-info",
    on: {
      "click": _vm.printLabels
    }
  }, [_vm._v("Print Labels")])])])])])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-xl-5 col-sm-9"
  }, [_c('div', {
    staticClass: "card"
  }, [_vm._m(2), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    staticClass: "clientLabel labelAbove",
    attrs: {
      "for": "clientName"
    }
  }, [_vm._v("Institution")]), _vm._v(" "), (_vm.accessionState.loaded) ? _c('multiselect', {
    attrs: {
      "id": "clientName",
      "options": _vm.accessionState.clients,
      "track-by": "id",
      "label": "name",
      "searchable": true,
      "close-on-select": true,
      "placeholder": "Type to Search..."
    },
    model: {
      value: (_vm.client),
      callback: function($$v) {
        _vm.client = $$v
      }
    }
  }) : _vm._e(), _vm._v(" "), _c('label', {
    staticClass: "facilityLabel labelAbove",
    attrs: {
      "for": "facilityName"
    }
  }, [_vm._v("Facility")]), _vm._v(" "), (_vm.accessionState.loaded) ? _c('multiselect', {
    attrs: {
      "id": "facilityName",
      "options": this.facilities,
      "track-by": "id",
      "label": "name",
      "searchable": true,
      "close-on-select": true,
      "placeholder": "Select..."
    },
    model: {
      value: (_vm.facility),
      callback: function($$v) {
        _vm.facility = $$v
      }
    }
  }) : _vm._e()], 1), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    staticClass: "labLabel labelAbove",
    attrs: {
      "for": "labName"
    }
  }, [_vm._v("Received At")]), _vm._v(" "), (_vm.accessionState.loaded) ? _c('multiselect', {
    attrs: {
      "id": "labName",
      "options": _vm.accessionState.labs,
      "track-by": "id",
      "label": "name",
      "searchable": true,
      "close-on-select": true,
      "placeholder": "Type to Search..."
    },
    model: {
      value: (_vm.lab),
      callback: function($$v) {
        _vm.lab = $$v
      }
    }
  }) : _vm._e()], 1)])])]), _vm._v(" "), _c('div', {
    staticClass: "col-xl-5 col-sm-12"
  }, [(_vm.accessionState.loaded && _vm.organization.href != null) ? _c('Patient', {
    attrs: {
      "prop_patientId": _vm.accessionState.isNew ? 0 : _vm.accessionState.accession.patientId,
      "prop_mrn": _vm.accessionState.isNew ? '' : _vm.accessionState.accession.mrn,
      "prop_organization": this.organization,
      "prop_user": this.user,
      "prop_patients": this.accessionState.patients
    },
    on: {
      "new": _vm.patient_changed,
      "changed": _vm.patient_changed
    }
  }) : _vm._e()], 1)]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [(_vm.accessionState.loaded) ? _c('Specimens', {
    attrs: {
      "specimens": _vm.accessionState.accession.specimens,
      "organization": _vm.organization
    },
    on: {
      "changed": _vm.specimens_changed
    }
  }) : _vm._e()], 1)])]) : _vm._e()])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "col-sm-12"
  }, [_c('i', {
    staticClass: "icon-chemistry font-2xl mr-1 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "text-uppercase font-weight-bold font-xs"
  }, [_vm._v("New "), _c('span', {
    staticClass: "accessionLabel"
  }, [_vm._v("Accession")])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('button', {
    staticClass: "btn btn-info dropdown-toggle w-100",
    attrs: {
      "type": "button",
      "id": "printDropdown",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('i', {
    staticClass: "fa fa-print font-2xl float-left"
  }), _vm._v("\n                                                Print\n                                            ")])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-header card-header-primary"
  }, [_c('span', {
    staticClass: "clientDetailsLabel"
  }, [_vm._v("Accession Details")])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-4da0d858", module.exports)
  }
}

/***/ }),

/***/ 666:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "container-fluid pl-0"
  }, [_c('div', {
    staticClass: "card card-accent-primary card-compact"
  }, [_c('div', {
    staticClass: "card-header bg-gray-lightest font-weight-bold"
  }, [_vm._v("\n            Specimen # " + _vm._s(_vm.specimen.id) + " - " + _vm._s(_vm.specimen.type.type) + " " + _vm._s(_vm.specimen.transport == null || _vm.specimen.transport.name == null ? '' : '| ' + _vm.specimen.transport.name) + "\n            "), (_vm.$route.name === 'Specimen Catalog') ? _c('div', {
    staticClass: "float-right"
  }, [_vm._v("\n                " + _vm._s('USD ' + _vm.currentSpecimenAttributeValue(_vm.specimen, 'cost', false) !== '' ? _vm.currentSpecimenAttributeValue(_vm.specimen, 'cost', false) : '40') + "\n                "), _c('button', {
    staticClass: "btn btn-info btn-sm"
  }, [_vm._v("Purchase Specimen")])]) : _vm._e()]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [(_vm.$route.name !== 'Specimen Catalog') ? _c('div', {
    staticClass: "row m-0"
  }, [_vm._m(0), _vm._v(" "), (_vm.specimen.id % 2 === 0) ? _c('div', {
    staticClass: "col-sm-3 m-0 p-0"
  }, [_vm._m(1), _vm._v(" "), _vm._m(2)]) : _vm._e(), _vm._v(" "), (_vm.specimen.id % 2 !== 0) ? _c('div', {
    staticClass: "col-sm-3 m-0 p-0"
  }, [_vm._m(3), _vm._v(" "), _vm._m(4)]) : _vm._e(), _vm._v(" "), _vm._m(5), _vm._v(" "), _c('div', {
    staticClass: "col-sm-5 m-0 p-0"
  }, [_c('div', {
    staticClass: "row"
  }, [_vm._m(6), _vm._v(" "), (_vm.specimen.id % 2 === 0) ? _c('div', {
    staticClass: "col-sm-auto"
  }, [_vm._v("\n                            Building 2 Refrigerator 5 Top Shelf\n                        ")]) : _vm._e(), _vm._v(" "), (_vm.specimen.id % 2 !== 0) ? _c('div', {
    staticClass: "col-sm-auto"
  }, [_vm._v("\n                            Logistics Irvine Station 2\n                        ")]) : _vm._e()]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_vm._m(7), _vm._v(" "), (_vm.specimen.id % 2 === 0) ? _c('div', {
    staticClass: "col-sm-auto"
  }, [_vm._v("\n                            Mary Smith 3/14/2017 9:26\n                        ")]) : _vm._e(), _vm._v(" "), (_vm.specimen.id % 2 !== 0) ? _c('div', {
    staticClass: "col-sm-auto"
  }, [_vm._v("\n                            John Williams 3/12/2017 13:10\n                        ")]) : _vm._e()])])]) : _vm._e(), _vm._v(" "), _vm._l((_vm.organization.customData.specimenAccessionSections.rows), function(row) {
    return _c('div', {
      staticClass: "row m-0"
    }, _vm._l((row.cols), function(col) {
      return _c('div', {
        class: col.class + ' m-0 p-0'
      }, [_c('div', {
        staticClass: "card card-compact card-no-outer-border"
      }, [_c('div', {
        staticClass: "card-header"
      }, [_vm._v(_vm._s(col.sectionName))]), _vm._v(" "), _c('div', {
        staticClass: "card-block wrap-unset"
      }, _vm._l((_vm.getSpecimenAttributesBySection(col.sectionName, _vm.specimen.type.code)), function(att) {
        return _c('div', {
          staticClass: "row m-0"
        }, [_c('div', {
          staticClass: "col-sm-auto mr-1"
        }, [_c('label', {
          staticClass: "label-black",
          attrs: {
            "for": 'attValue' + _vm.specimen.id + att.name
          }
        }, [_c('strong', [_vm._v(_vm._s(att.label))]), _vm._v(":")])]), _vm._v(" "), _c('div', {
          staticClass: "col-sm-auto",
          attrs: {
            "id": 'attValue' + _vm.specimen.id + att.name
          }
        }, [(Array.isArray(_vm.currentSpecimenAttributeValue(_vm.specimen, att.name, false))) ? _c('div', {
          staticClass: "row m-0 p-0"
        }, _vm._l((_vm.currentSpecimenAttributeValue(_vm.specimen, att.name, false)), function(value) {
          return _c('div', {
            staticClass: "col-sm-12 m-0 p-0"
          }, [_vm._v("\n                                            " + _vm._s(value.name) + "\n                                        ")])
        })) : _c('div', {
          staticClass: "m-0 p-0"
        }, [_vm._v("\n                                        " + _vm._s(_vm.currentSpecimenAttributeValue(_vm.specimen, att.name, false).name) + "\n                                    ")])])])
      }))])])
    }))
  })], 2)])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "col-sm-2 m-0 p-0"
  }, [_c('label', {
    staticClass: "label-black"
  }, [_vm._v("Workflow Status:")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12 text-warning"
  }, [_vm._v("Received (0)")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('div', {
    staticClass: "progress"
  }, [_c('div', {
    staticClass: "progress-bar bg-warning",
    staticStyle: {
      "width": "20%"
    },
    attrs: {
      "aria-valuenow": "20",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12 text-success"
  }, [_vm._v("Archived (-1)")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('div', {
    staticClass: "progress"
  }, [_c('div', {
    staticClass: "progress-bar bg-success",
    staticStyle: {
      "width": "100%"
    },
    attrs: {
      "aria-valuenow": "100",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "col-sm-2 m-0 p-0"
  }, [_c('div', {
    staticStyle: {
      "width": "20px"
    }
  })])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "col-sm-auto"
  }, [_c('label', {
    staticClass: "label-black"
  }, [_vm._v("Location: ")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "col-sm-auto"
  }, [_c('label', {
    staticClass: "label-black"
  }, [_vm._v("Last Contact: ")])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-54eb603e", module.exports)
  }
}

/***/ }),

/***/ 667:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header card-header-primary"
  }, [_c('span', {
    staticClass: "specimensLabel"
  }, [_vm._v("Specimens")]), _c('div', {
    staticClass: "dropdown float-right"
  }, [_vm._m(0), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu",
    attrs: {
      "aria-labelledby": "addSpecBtn"
    }
  }, _vm._l((_vm.organizationSpecimenTypes), function(spec) {
    return _c('div', {
      staticClass: "dropdown-item",
      on: {
        "click": function($event) {
          _vm.addSpecimen(spec)
        }
      }
    }, [_vm._v(_vm._s(spec.type))])
  }))])]), _vm._v(" "), (_vm.specimens.length > 0) ? _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "no-more-tables"
  }, [_c('table', {
    staticClass: "table table-striped table-condensed table-gray",
    attrs: {
      "id": "specimenList",
      "role": "grid"
    }
  }, [_vm._m(1), _vm._v(" "), _vm._l((_vm.specimens), function(specimen) {
    return _c('tbody', [_c('tr', [_c('td', [_c('button', {
      staticClass: "btn btn-info btn-sm",
      on: {
        "click": function($event) {
          _vm.specimenClicked(specimen)
        }
      }
    }, [_vm._v("\n                                        " + _vm._s(specimen === _vm.currentSpecimen ? 'Done' : 'Click to View/Edit') + "\n                                    ")])]), _vm._v(" "), _c('td', {
      attrs: {
        "data-title": "Specimen #"
      }
    }, [_vm._v(_vm._s(specimen.id))]), _vm._v(" "), (specimen === _vm.currentSpecimen) ? _c('td', {
      attrs: {
        "data-title": "ID"
      }
    }, [_c('input', {
      directives: [{
        name: "model",
        rawName: "v-model",
        value: (specimen.externalSpecimenID),
        expression: "specimen.externalSpecimenID"
      }],
      attrs: {
        "type": "text"
      },
      domProps: {
        "value": (specimen.externalSpecimenID)
      },
      on: {
        "input": function($event) {
          if ($event.target.composing) { return; }
          specimen.externalSpecimenID = $event.target.value
        }
      }
    })]) : _c('td', {
      attrs: {
        "data-title": "ID"
      }
    }, [_vm._v(_vm._s(specimen.externalSpecimenID))]), _vm._v(" "), (specimen === _vm.currentSpecimen) ? _c('td', {
      attrs: {
        "data-title": "Barcode"
      }
    }, [_c('input', {
      attrs: {
        "type": "text",
        "placeholder": "[Auto-generated if empty]"
      }
    })]) : _c('td', {
      attrs: {
        "data-title": "Barcode"
      }
    }), _vm._v(" "), (specimen === _vm.currentSpecimen) ? _c('td', {
      attrs: {
        "data-title": "Type"
      }
    }, [_c('multiselect', {
      attrs: {
        "placeholder": "Select Type",
        "track-by": "code",
        "label": "type",
        "options": _vm.organizationSpecimenTypes,
        "searchable": false,
        "multiple": false,
        "allow-empty": false,
        "selectLabel": '',
        "selectedLabel": '',
        "deselectLabel": ''
      },
      on: {
        "input": function($event) {
          _vm.currentSpecimenTypeTransportChanged()
        }
      },
      model: {
        value: (specimen.type),
        callback: function($$v) {
          specimen.type = $$v
        }
      }
    })], 1) : _c('td', {
      attrs: {
        "data-title": "Type"
      }
    }, [_vm._v(_vm._s(specimen.type.type))]), _vm._v(" "), (specimen === _vm.currentSpecimen) ? _c('td', {
      attrs: {
        "data-title": "Transport"
      }
    }, [_c('multiselect', {
      attrs: {
        "placeholder": "Select Transport",
        "track-by": "code",
        "label": "name",
        "options": _vm.getSpecimenTransports(specimen.type.code),
        "searchable": false,
        "multiple": false,
        "allow-empty": false,
        "selectLabel": '',
        "selectedLabel": '',
        "deselectLabel": ''
      },
      on: {
        "input": function($event) {
          _vm.currentSpecimenTypeTransportChanged()
        }
      },
      model: {
        value: (specimen.transport),
        callback: function($$v) {
          specimen.transport = $$v
        }
      }
    })], 1) : _c('td', {
      attrs: {
        "data-title": "Transport"
      }
    }, [_vm._v(_vm._s(specimen.transport.name))]), _vm._v(" "), (specimen === _vm.currentSpecimen) ? _c('td', {
      attrs: {
        "data-title": "Collected"
      }
    }, [_c('input', {
      directives: [{
        name: "model",
        rawName: "v-model.lazy",
        value: (_vm.currentSpecimen.collectionDate),
        expression: "currentSpecimen.collectionDate",
        modifiers: {
          "lazy": true
        }
      }],
      staticClass: "dateTimePicker",
      attrs: {
        "type": "text"
      },
      domProps: {
        "value": (_vm.currentSpecimen.collectionDate)
      },
      on: {
        "change": function($event) {
          _vm.currentSpecimen.collectionDate = $event.target.value
        }
      }
    })]) : _c('td', {
      attrs: {
        "data-title": "Collected"
      }
    }, [_vm._v(_vm._s(_vm._f("localeDate")(specimen.collectionDate)))]), _vm._v(" "), (specimen === _vm.currentSpecimen) ? _c('td', {
      attrs: {
        "data-title": "Qty"
      }
    }, [_c('input', {
      attrs: {
        "type": "number",
        "value": "2"
      }
    })]) : _c('td', {
      attrs: {
        "data-title": "Qty"
      }
    }, [_c('button', {
      staticClass: "btn btn-info btn-sm"
    }, [_vm._v("2 like this - show all")])])]), _vm._v(" "), (specimen === _vm.currentSpecimen) ? _c('tr', {
      staticClass: "ignore-no-more-tables"
    }, [_c('td', {
      staticClass: "bg-faded",
      attrs: {
        "colspan": "9"
      }
    }, [_c('div', {
      staticClass: "ml-1 mb-1 text-center"
    }, [_c('span', {
      staticClass: "specimenLabel"
    }, [_vm._v("Specimen")]), _vm._v(":\n                                        " + _vm._s(specimen.id === -1 ? '(NEW)' : '# ' + specimen.id) + "\n                                        | " + _vm._s((specimen.externalSpecimenID === "" || specimen.externalSpecimenID === null) ? '(No ID Set)' : specimen.externalSpecimenID) + "\n                                        | Code: " + _vm._s(specimen.code) + "\n                                    ")]), _vm._v(" "), _c('div', {
      staticClass: "row collapse m-0 p-0",
      attrs: {
        "id": 'collapse' + specimen.guid,
        "role": "tabpanel",
        "aria-labelledby": 'heading' + specimen.guid
      }
    }, [(specimen.attributesAreSet) ? _c('div', {
      staticClass: "col-sm-12"
    }, _vm._l((_vm.organization.customData.specimenAccessionSections.rows), function(row) {
      return _c('div', {
        staticClass: "row"
      }, _vm._l((row.cols), function(col) {
        return _c('div', {
          class: col.class
        }, [_c('div', {
          staticClass: "card"
        }, [_c('div', {
          staticClass: "card-header card-header-primary"
        }, [_vm._v("\n                                                            " + _vm._s(col.sectionName) + "\n                                                        ")]), _vm._v(" "), _c('div', {
          staticClass: "card-block"
        }, _vm._l((_vm.getSpecimenAttributesBySection(col.sectionName, specimen.type.code)), function(att) {
          return _c('div', {
            staticClass: "form-group"
          }, [_c('label', {
            staticClass: "labelAbove",
            attrs: {
              "for": specimen.guid + '_' + att.name + '_' + att.type
            }
          }, [_vm._v(_vm._s(att.label))]), _vm._v(" "), _c('div', {
            staticClass: "input-group"
          }, [(att.type === 'smallText') ? _c('input', {
            attrs: {
              "type": "text",
              "id": specimen.guid + '_' + att.name + '_' + att.type
            },
            domProps: {
              "value": att.value
            },
            on: {
              "change": _vm.updateSpecimenAttributeFromText
            }
          }) : _vm._e(), _vm._v(" "), (att.type === 'integer') ? _c('input', _vm._b({
            attrs: {
              "type": "number",
              "id": specimen.guid + '_' + att.name + '_' + att.type
            },
            on: {
              "change": _vm.updateSpecimenAttributeFromText
            }
          }, 'input', att.value)) : _vm._e(), _vm._v(" "), (att.type === 'single-small') ? _c('div', {
            staticClass: "btn-group pl-1",
            attrs: {
              "id": specimen.guid + '_' + att.name + '_' + att.type,
              "data-toggle": "buttons"
            }
          }, _vm._l((att.options), function(option) {
            return _c('label', {
              class: option.id === _vm.currentSpecimenAttributeValue(specimen, att.name, true).id ? 'btn btn- btn-radio active' : 'btn btn-radio',
              on: {
                "click": function($event) {
                  _vm.updateSpecimenAttribute(specimen, att.name, option, true)
                }
              }
            }, [_c('input', {
              attrs: {
                "type": "radio",
                "autocomplete": "off",
                "name": "option",
                "id": option.id
              },
              domProps: {
                "checked": option.id === _vm.currentSpecimenAttributeValue(specimen, att.name, true).id
              },
              on: {
                "change": function($event) {
                  _vm.updateSpecimenAttribute(specimen, att.name, option, false)
                }
              }
            }), _vm._v("\n                                                                            " + _vm._s(option.name) + "\n                                                                        ")])
          })) : _vm._e(), _vm._v(" "), (att.type === 'multiple-small') ? _c('div', {
            staticClass: "btn-group pl-1",
            attrs: {
              "id": specimen.guid + '_' + att.name + '_' + att.type,
              "data-toggle": "buttons"
            }
          }, _vm._l((att.options), function(option) {
            return _c('label', {
              staticClass: "btn btn-radio",
              class: _vm.currentSpecimenAttributeValue(specimen, att.name, false).find(function(v) {
                option.id === v.id
              }) ? 'btn btn-radio active' : 'btn btn-radio',
              on: {
                "click": function($event) {
                  _vm.updateSpecimenAttribute(specimen, att.name, option, true)
                }
              }
            }, [_c('input', {
              attrs: {
                "type": "checkbox",
                "autocomplete": "off",
                "name": "option",
                "id": option.id
              },
              domProps: {
                "checked": _vm.currentSpecimenAttributeValue(specimen, att.name, false).find(function(v) {
                  option.id === v.id
                })
              },
              on: {
                "change": function($event) {
                  _vm.updateSpecimenAttribute(specimen, att.name, option, true)
                }
              }
            }), _vm._v("\n                                                                            " + _vm._s(option.name) + "\n                                                                        ")])
          })) : _vm._e(), _vm._v(" "), (att.type === 'single-large') ? _c('multiselect', {
            attrs: {
              "id": specimen.guid + '_' + att.name + '_' + att.type,
              "deselect-label": "Can't remove this value",
              "track-by": "id",
              "label": "name",
              "placeholder": "Select one",
              "options": att.options,
              "searchable": false,
              "allow-empty": true,
              "value": _vm.currentSpecimenAttributeValue(specimen, att.name, true)
            },
            on: {
              "input": _vm.updateSpecimenAttributeFromMultiSelect
            }
          }) : _vm._e(), _vm._v(" "), (att.type === 'multiple-large') ? _c('multiselect', {
            attrs: {
              "id": specimen.guid + '_' + att.name + '_' + att.type,
              "track-by": "id",
              "label": "name",
              "placeholder": "Select one or more",
              "options": att.options,
              "searchable": true,
              "multiple": true,
              "allow-empty": true,
              "value": _vm.currentSpecimenAttributeValue(specimen, att.name, false)
            },
            on: {
              "input": _vm.updateSpecimenAttributeFromMultiSelect
            }
          }) : _vm._e(), _vm._v(" "), (att.type === 'civic-gene-api') ? _c('CivicGeneSelectionPlugin', {
            attrs: {
              "prop_id": specimen.guid + '_' + att.name + '_multiple-large',
              "prop_value": _vm.currentSpecimenAttributeValue(specimen, att.name, false),
              "prop_genes": _vm.civicGenesCache
            },
            on: {
              "genesChanged": _vm.updateSpecimenAttributeFromMultiSelect,
              "genesRetrieved": _vm.cacheCivicGenes
            }
          }) : _vm._e(), _vm._v(" "), (att.informationTooltip != null) ? _c('span', {
            staticClass: "input-group-addon-clean-small-icon",
            attrs: {
              "data-toggle": "tooltip",
              "data-placement": "top",
              "title": att.informationToolTip
            }
          }, [(att.informationSource != null) ? _c('a', {
            attrs: {
              "href": att.informationSource,
              "target": "_new"
            }
          }, [_c('i', {
            staticClass: "fa fa-info"
          })]) : _c('i', {
            staticClass: "fa fa-info"
          })]) : _vm._e()], 1)])
        }))])])
      }))
    })) : _vm._e()])])]) : _vm._e()])
  })], 2)])]) : _vm._e()])])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('button', {
    staticClass: "btn btn-info btn-sm dropdown-toggle",
    attrs: {
      "id": "addSpecBtn",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('i', {
    staticClass: "fa fa-plus-circle"
  }), _vm._v(" Add Specimen\n                    ")])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('thead', [_c('tr', [_c('th', [_vm._v("Edit")]), _vm._v(" "), _c('th', [_vm._v("#")]), _vm._v(" "), _c('th', [_vm._v("ID")]), _vm._v(" "), _c('th', [_vm._v("Barcode")]), _vm._v(" "), _c('th', [_vm._v("Type")]), _vm._v(" "), _c('th', [_vm._v("Transport")]), _vm._v(" "), _c('th', [_vm._v("Collection Date")]), _vm._v(" "), _c('th', [_vm._v("Quantity")])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-5d660145", module.exports)
  }
}

/***/ }),

/***/ 668:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "container-fluid pt-2"
  }, [_vm._v("\n    WIP (isn't it all?)\n    "), _vm._m(0), _vm._v(" "), _c('div', {
    staticClass: "tab-content"
  }, [_c('div', {
    staticClass: "tab-pane p-1 active",
    attrs: {
      "id": "organization",
      "role": "tabpanel"
    }
  }, [_c('Organization')], 1), _vm._v(" "), _c('div', {
    staticClass: "tab-pane p-1",
    attrs: {
      "id": "users",
      "role": "tabpanel"
    }
  }, [_vm._v("...")])])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('ul', {
    staticClass: "nav nav-tabs",
    attrs: {
      "role": "tablist"
    }
  }, [_c('li', {
    staticClass: "nav-item"
  }, [_c('a', {
    staticClass: "nav-link active",
    attrs: {
      "data-toggle": "tab",
      "href": "#organization",
      "role": "tab",
      "aria-controls": "organization"
    }
  }, [_vm._v("Organization")])]), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('a', {
    staticClass: "nav-link active",
    attrs: {
      "data-toggle": "tab",
      "href": "#users",
      "role": "tab",
      "aria-controls": "users"
    }
  }, [_vm._v("Users")])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-6a867329", module.exports)
  }
}

/***/ }),

/***/ 669:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "container-fluid m-0 p-0"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-3"
  }), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6"
  }, [_c('ScanLookup', {
    on: {
      "scan": _vm.scanLookup
    }
  })], 1), _vm._v(" "), _c('div', {
    staticClass: "col-sm-3"
  }, [_vm._v("Dashboard config here")])]), _vm._v(" "), _vm._m(0)])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-3"
  }, [_vm._v("\n            Left Features here\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-9"
  }, [_c('div', {
    staticClass: "row"
  }), _vm._v(" "), _c('div', {
    staticClass: "row"
  }), _vm._v(" "), _c('div', {
    staticClass: "row"
  }), _vm._v(" "), _c('div', {
    staticClass: "row"
  })])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-6f9f3a88", module.exports)
  }
}

/***/ }),

/***/ 670:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "container-fluid pl-0"
  }, [_c('div', {
    staticClass: "card card-accent-primary card-compact"
  }, [_c('div', {
    staticClass: "card-header card-compact"
  }, [_c('span', {
    staticClass: "caseLabel"
  }, [_vm._v("Case")]), _vm._v(" # " + _vm._s(_vm._case.id) + " - " + _vm._s(_vm._case.type))]), _vm._v(" "), _c('div', {
    staticClass: "card-block card-compact"
  })])])
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-710624e6", module.exports)
  }
}

/***/ }),

/***/ 671:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "table-responsive",
    attrs: {
      "id": "worklistTableWrapper"
    }
  }, [_c('table', {
    staticClass: "nowrap table table-bordered table-condensed table-hover table-primary",
    attrs: {
      "id": "worklistTable"
    }
  }, [_vm._m(0), _vm._v(" "), _c('tbody', _vm._l((_vm.worklist), function(row) {
    return _c('tr', [_c('td', [_c('AccessionInfo', {
      attrs: {
        "organization": _vm.organization,
        "accession": row,
        "labs": _vm.state.labs,
        "clients": _vm.state.clients,
        "patients": _vm.state.patients,
        "doctors": _vm.state.doctors
      }
    })], 1), _vm._v(" "), _c('td', [_c('WorklistSpecimens', {
      attrs: {
        "organization": _vm.organization,
        "specimens": row.specimens
      }
    })], 1)])
  }))])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('thead', [_c('tr', [_c('th', {
    staticClass: "accessionLabel"
  }, [_vm._v("Accession")]), _vm._v(" "), _c('th', {
    staticClass: "specimenLabel"
  }, [_vm._v("Specimen")])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-765e9c36", module.exports)
  }
}

/***/ }),

/***/ 672:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('section', {
    staticClass: "content"
  }, [_c('div', {
    staticClass: "center-block"
  }, [_c('h1', {
    staticClass: "text-center"
  }, [_vm._v("Tasks")]), _vm._v(" "), _c('ul', {
    staticClass: "timeline"
  }, [_c('li', {
    staticClass: "time-label"
  }, [_c('span', {
    staticClass: "bg-green"
  }, [_vm._v(_vm._s(_vm.today))])]), _vm._v(" "), _vm._l((_vm.timeline), function(line) {
    return _c('li', [_c('i', {
      class: 'fa ' + line.icon + ' bg-' + line.color
    }), _vm._v(" "), _c('div', {
      staticClass: "timeline-item"
    }, [_c('span', {
      staticClass: "time"
    }, [_c('i', {
      staticClass: "fa fa-clock-o"
    }), _vm._v(" " + _vm._s(line.time))]), _vm._v(" "), _c('h3', {
      staticClass: "timeline-header"
    }, [_vm._v(_vm._s(line.title))]), _vm._v(" "), (line.body) ? _c('div', {
      staticClass: "timeline-body",
      domProps: {
        "innerHTML": _vm._s(line.body)
      }
    }) : _vm._e(), _vm._v(" "), (line.buttons) ? _c('div', {
      staticClass: "timeline-footer"
    }, _vm._l((line.buttons), function(btn) {
      return _c('a', {
        class: 'btn btn-' + btn.type + ' btn-xs'
      }, [_vm._v(_vm._s(btn.message))])
    })) : _vm._e()])])
  })], 2)])])
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-7c6f53a3", module.exports)
  }
}

/***/ }),

/***/ 673:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card"
  }, [_vm._m(0), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    staticClass: "patientLabel labelAbove",
    attrs: {
      "for": "patientName"
    }
  }, [_vm._v("Patient")]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('multiselect', {
    attrs: {
      "id": "patientName",
      "options": this.prop_patients,
      "track-by": "id",
      "label": "fullName",
      "option-height": 104,
      "searchable": true,
      "custom-label": _vm.customPatientDropdownLabel,
      "show-labels": false,
      "internal-search": true,
      "clear-on-select": true,
      "close-on-select": true,
      "allow-empty": false,
      "placeholder": "Type to Search..."
    },
    on: {
      "input": _vm.patientChanged,
      "search-change": _vm.patientSearched
    },
    scopedSlots: _vm._u([
      ["option", function(props) {
        return [_c('div', {
          attrs: {
            "id": props.option.id
          }
        }, [_vm._v(_vm._s(props.option.lastName) + ", " + _vm._s(props.option.firstName)), _c('br'), _vm._v("DOB: " + _vm._s(_vm._f("prettyDate")(props.option.dob))), _c('br'), _vm._v("SSN: " + _vm._s(props.option.ssn))])]
      }]
    ]),
    model: {
      value: (_vm.patientState.patient),
      callback: function($$v) {
        _vm.patientState.patient = $$v
      }
    }
  }, [_c('span', {
    slot: "noResult"
  }, [_vm._v("No Patients Found.  "), _c('button', {
    staticClass: "btn btn-info btn-sm",
    on: {
      "click": _vm.newPatient
    }
  }, [_vm._v("New Patient")])])])], 1)]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "form-group col-lg-6 col-sm-auto"
  }, [_c('label', {
    staticClass: "labelAbove",
    attrs: {
      "for": "firstNameField"
    }
  }, [_vm._v("First Name")]), _vm._v(" "), _c('input', {
    directives: [{
      name: "model",
      rawName: "v-model",
      value: (_vm.patientState.patient.firstName),
      expression: "patientState.patient.firstName"
    }],
    staticClass: "form-control",
    attrs: {
      "id": "firstNameField",
      "type": "text",
      "disabled": !this.allowEditSave
    },
    domProps: {
      "value": (_vm.patientState.patient.firstName)
    },
    on: {
      "input": function($event) {
        if ($event.target.composing) { return; }
        _vm.patientState.patient.firstName = $event.target.value
      }
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group col-lg-6 col-sm-auto"
  }, [_c('label', {
    staticClass: "labelAbove",
    attrs: {
      "for": "lastNameField"
    }
  }, [_vm._v("Last Name")]), _vm._v(" "), _c('input', {
    directives: [{
      name: "model",
      rawName: "v-model",
      value: (_vm.patientState.patient.lastName),
      expression: "patientState.patient.lastName"
    }],
    staticClass: "form-control",
    attrs: {
      "id": "lastNameField",
      "type": "text",
      "disabled": !this.allowEditSave
    },
    domProps: {
      "value": (_vm.patientState.patient.lastName)
    },
    on: {
      "input": function($event) {
        if ($event.target.composing) { return; }
        _vm.patientState.patient.lastName = $event.target.value
      }
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "form-group col-lg-4 col-sm-auto"
  }, [_c('label', {
    staticClass: "labelAbove",
    attrs: {
      "for": "ssnField"
    }
  }, [_vm._v("SSN")]), _vm._v(" "), _c('input', {
    directives: [{
      name: "model",
      rawName: "v-model",
      value: (_vm.patientState.patient.ssn),
      expression: "patientState.patient.ssn"
    }],
    staticClass: "form-control",
    attrs: {
      "id": "ssnField",
      "type": "text",
      "disabled": !this.allowEditSave
    },
    domProps: {
      "value": (_vm.patientState.patient.ssn)
    },
    on: {
      "input": function($event) {
        if ($event.target.composing) { return; }
        _vm.patientState.patient.ssn = $event.target.value
      }
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group col-lg-4 col-sm-auto"
  }, [_c('label', {
    staticClass: "labelAbove",
    attrs: {
      "for": "dobField"
    }
  }, [_vm._v("DOB")]), _vm._v(" "), _c('div', {
    staticClass: "datefield text-nowrap",
    attrs: {
      "id": "dobField"
    }
  }, [_c('input', {
    directives: [{
      name: "model",
      rawName: "v-model.number",
      value: (_vm.computedDobMonth),
      expression: "computedDobMonth",
      modifiers: {
        "number": true
      }
    }],
    attrs: {
      "id": "month",
      "type": "text",
      "maxlength": "2",
      "placeholder": "MM",
      "disabled": !this.allowEditSave
    },
    domProps: {
      "value": (_vm.computedDobMonth)
    },
    on: {
      "input": function($event) {
        if ($event.target.composing) { return; }
        _vm.computedDobMonth = _vm._n($event.target.value)
      },
      "blur": function($event) {
        _vm.$forceUpdate()
      }
    }
  }), _vm._v("/\n                        "), _c('input', {
    directives: [{
      name: "model",
      rawName: "v-model.number",
      value: (_vm.computedDobDay),
      expression: "computedDobDay",
      modifiers: {
        "number": true
      }
    }],
    attrs: {
      "id": "day",
      "type": "text",
      "maxlength": "2",
      "placeholder": "DD",
      "disabled": !this.allowEditSave
    },
    domProps: {
      "value": (_vm.computedDobDay)
    },
    on: {
      "input": function($event) {
        if ($event.target.composing) { return; }
        _vm.computedDobDay = _vm._n($event.target.value)
      },
      "blur": function($event) {
        _vm.$forceUpdate()
      }
    }
  }), _vm._v(" /\n                        "), _c('input', {
    directives: [{
      name: "model",
      rawName: "v-model.number",
      value: (_vm.computedDobYear),
      expression: "computedDobYear",
      modifiers: {
        "number": true
      }
    }],
    attrs: {
      "id": "year",
      "type": "text",
      "maxlength": "4",
      "placeholder": "YYYY",
      "disabled": !this.allowEditSave
    },
    domProps: {
      "value": (_vm.computedDobYear)
    },
    on: {
      "input": function($event) {
        if ($event.target.composing) { return; }
        _vm.computedDobYear = _vm._n($event.target.value)
      },
      "blur": function($event) {
        _vm.$forceUpdate()
      }
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group col-lg-4 col-sm-auto"
  }, [_c('label', {
    staticClass: "labelAbove",
    attrs: {
      "for": "mrnField"
    }
  }, [_vm._v("MRN")]), _vm._v(" "), _c('input', {
    directives: [{
      name: "model",
      rawName: "v-model",
      value: (_vm.patientState.mrn),
      expression: "patientState.mrn"
    }],
    staticClass: "form-control",
    attrs: {
      "id": "mrnField",
      "type": "text",
      "disabled": !this.allowEditSave
    },
    domProps: {
      "value": (_vm.patientState.mrn)
    },
    on: {
      "input": function($event) {
        if ($event.target.composing) { return; }
        _vm.patientState.mrn = $event.target.value
      }
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-lg-6 col-sm-auto"
  }, [_c('button', {
    staticClass: "btn btn-info w-100",
    on: {
      "click": function($event) {
        _vm.uploadDocument('PatientConsent')
      }
    }
  }, [_c('i', {
    staticClass: "fa fa-paperclip"
  }), _vm._v("\n                        Attach Consent\n                    ")])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-sm-auto"
  }, [(this.allowEditSave) ? _c('button', {
    staticClass: "btn btn-info w-100",
    on: {
      "click": _vm.savePatient
    }
  }, [_c('i', {
    staticClass: "fa fa-save"
  }), _vm._v("\n                        Save Patient\n                    ")]) : _vm._e()])])])])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-header card-header-primary"
  }, [_c('span', {
    staticClass: "patientDetailsLabel"
  }, [_vm._v("Patient/Subject Details")]), _vm._v(" "), _c('div', {
    staticClass: "float-right text-white config-info"
  }, [_vm._v("To prevent duplicate entries, please search before entering a new record.")])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-91458d42", module.exports)
  }
}

/***/ }),

/***/ 674:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('router-view')
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-96021bf4", module.exports)
  }
}

/***/ }),

/***/ 675:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', [_c('div', {
    staticClass: "input-group"
  }, [_c('i', {
    staticClass: "fa fa-search input-group-addon"
  }), _vm._v(" "), _c('input', {
    directives: [{
      name: "model",
      rawName: "v-model",
      value: (_vm.value),
      expression: "value"
    }],
    staticClass: "form-control focusDefault",
    attrs: {
      "type": "text",
      "placeholder": _vm.currentAction.label
    },
    domProps: {
      "value": (_vm.value)
    },
    on: {
      "change": _vm.scanLookup,
      "input": function($event) {
        if ($event.target.composing) { return; }
        _vm.value = $event.target.value
      }
    }
  }), _vm._v(" "), _c('div', {
    staticClass: "input-group-btn"
  }, [_c('button', {
    staticClass: "btn dropdown-toggle",
    attrs: {
      "type": "button",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_vm._v("\n                " + _vm._s(_vm.currentAction.label) + "\n            ")]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu"
  }, _vm._l((this.actions), function(action) {
    return _c('div', {
      class: 'dropdown-item ' + (_vm.currentAction === action ? 'active' : ''),
      on: {
        "click": function($event) {
          _vm.setAction(action)
        }
      }
    }, [_vm._v(_vm._s(action.label))])
  }))])])])
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-96376114", module.exports)
  }
}

/***/ }),

/***/ 676:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, _vm._l((_vm.specimens), function(specimen) {
    return _c('div', {
      staticClass: "col-sm-12"
    }, [_c('WorklistSpecimenDetail', {
      attrs: {
        "organization": _vm.organization,
        "specimen": specimen
      }
    })], 1)
  }))
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-9c300a94", module.exports)
  }
}

/***/ }),

/***/ 677:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "app-root"
  }, [_c('Navbar', {
    attrs: {
      "name": "topNavBar",
      "user": this.user,
      "organization": this.organization
    }
  }), _vm._v(" "), _c('div', {
    staticClass: "app-body"
  }, [_c('Sidebar', {
    attrs: {
      "name": "leftSidebar"
    }
  }), _vm._v(" "), _c('main', {
    staticClass: "main"
  }, [_c('section', {
    staticClass: "content-header"
  }, [_c('h1', [_vm._v("\n                    " + _vm._s(_vm.$route.name.toUpperCase()) + "\n                    "), _c('small', [_vm._v(_vm._s(_vm.$route.description))])]), _vm._v(" "), _c('nav', {
    staticClass: "breadcrumb"
  }, [_c('router-link', {
    staticClass: "breadcrumb-item",
    attrs: {
      "exact": "",
      "to": "/"
    }
  }, [_c('i', {
    staticClass: "fa fa-home"
  }), _vm._v("Home")]), _vm._v(" "), _c('span', {
    staticClass: "active breadcrumb-item"
  }, [_vm._v(_vm._s(_vm.$route.name.toUpperCase()))])], 1)]), _vm._v(" "), _c('div', {
    staticClass: "container-fluid pt-lg-1 pt-md-1 pt-sm-0"
  }, [(this.organization != null) ? _c('div', {
    staticClass: "animated fadeIn"
  }, [(this.organization.customData != null) ? _c('router-view', {
    attrs: {
      "user": this.user,
      "organization": this.organization
    },
    on: {
      "viewEditItem": _vm.setHistoryItem
    }
  }) : _vm._e()], 1) : _vm._e()])]), _vm._v(" "), _c('SecondarySidebar', {
    attrs: {
      "name": "rightSidebar",
      "user": this.user,
      "organization": this.organization,
      "historyItems": this.historyItems
    }
  })], 1), _vm._v(" "), _c('AppFooter', {
    attrs: {
      "name": "footer",
      "organization": this.organization
    }
  })], 1)
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-b139a0b8", module.exports)
  }
}

/***/ }),

/***/ 678:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "aside-menu"
  }, [_c('span', {
    staticStyle: {
      "display": "none"
    }
  }, [_vm._v(_vm._s(_vm.user.userName))]), _vm._v(" "), _c('ul', {
    staticClass: "nav nav-tabs",
    attrs: {
      "role": "tablist"
    }
  }, [(this.$route.meta.hasHistoryItems) ? _c('li', {
    staticClass: "nav-item"
  }, [_c('a', {
    staticClass: "nav-link active",
    attrs: {
      "data-toggle": "tab",
      "href": "#recent",
      "role": "tab"
    }
  }, [_c('i', {
    staticClass: "fa fa-history"
  }), _vm._v(" "), (typeof _vm.historyItems !== 'undefined') ? _c('span', {
    staticClass: "label label-info"
  }, [_vm._v(_vm._s(_vm.historyItems.length))]) : _vm._e()])]) : _vm._e(), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('a', {
    class: 'nav-link' + (!this.$route.meta.hasHistoryItems ? ' active' : ''),
    attrs: {
      "data-toggle": "tab",
      "href": "#messages",
      "role": "tab"
    }
  }, [_c('i', {
    staticClass: "icon-envelope-letter"
  }), _vm._v(" "), _c('span', {
    staticClass: "label label-success"
  }, [_vm._v(_vm._s(_vm.user.messageCount))])])]), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('a', {
    staticClass: "nav-link",
    attrs: {
      "data-toggle": "tab",
      "href": "#notifications",
      "role": "tab"
    }
  }, [_c('i', {
    staticClass: "icon-bell"
  }), _vm._v(" "), _c('span', {
    staticClass: "label label-warning"
  }, [_vm._v(_vm._s(_vm.user.notificationCount))])])])]), _vm._v(" "), _c('div', {
    staticClass: "tab-content"
  }, [(this.$route.meta.hasHistoryItems) ? _c('div', {
    staticClass: "tab-pane p-1 active",
    attrs: {
      "id": "recent",
      "role": "tabpanel"
    }
  }, [_c('div', {
    staticClass: "header"
  }, [_c('strong', [_vm._v("Recent " + _vm._s(this.$route.meta.historyItemName))])]), _vm._v(" "), (typeof _vm.historyItems !== 'undefined' && _vm.historyItems.length > 0) ? _c('div', _vm._l((_vm.orderBy(_vm.historyItems, 'timeStamp', -1)), function(item) {
    return _c('div', [_c('div', {
      staticClass: "message"
    }, [_c('router-link', {
      staticClass: "dropdown-item",
      attrs: {
        "exact": "",
        "to": {
          name: 'Edit Accession',
          params: {
            orgNameKey: _vm.organization.nameKey,
            id: item.id
          }
        }
      }
    }, [_c('div', [_c('small', {
      staticClass: "text-muted"
    }, [_vm._v(_vm._s(item.title))]), _vm._v(" "), _c('small', {
      staticClass: "text-muted float-right mt-q"
    }, [_vm._v("\n                                    " + _vm._s(_vm._f("localeDateOrTimeToday")(item.timeStamp)) + "\n                                ")])]), _vm._v(" "), _c('div', {
      staticClass: "text-truncate font-weight-bold"
    }, [_vm._v(_vm._s(item.headline))]), _vm._v(" "), _c('div', {
      staticClass: "text-muted"
    }, [_vm._v(_vm._s(_vm._f("truncate")(item.content)))])])], 1), _vm._v(" "), _c('hr')])
  })) : _c('div', [_vm._v("None Available")])]) : _vm._e(), _vm._v(" "), _c('div', {
    class: 'tab-pane p-1' + (!this.$route.meta.hasHistoryItems ? ' active' : ''),
    attrs: {
      "id": "messages",
      "role": "tabpanel"
    }
  }, [_c('div', {
    staticClass: "header"
  }, [_c('strong', [_vm._v("You have " + _vm._s(_vm.user.messageCount) + " message(s)")])]), _vm._v(" "), (_vm.user.hasMessages) ? _c('div', [_vm._l((_vm.user.customData.messages), function(message) {
    return _c('div', [_c('div', {
      staticClass: "message"
    }, [_c('router-link', {
      staticClass: "dropdown-item",
      attrs: {
        "exact": "",
        "to": {
          name: 'Mailbox',
          params: {
            type: 'messages'
          }
        }
      }
    }, [_c('div', [_c('small', {
      staticClass: "text-muted"
    }, [_vm._v(_vm._s(message.from))]), _vm._v(" "), _c('small', {
      staticClass: "text-muted float-right mt-q"
    }, [_vm._v("\n                                    " + _vm._s(_vm._f("localeDateOrTimeToday")(message.timeStamp)) + "\n                                ")])]), _vm._v(" "), _c('div', {
      staticClass: "text-truncate font-weight-bold"
    }, [_vm._v(_vm._s(message.subject))]), _vm._v(" "), _c('div', {
      staticClass: "text-muted"
    }, [_vm._v(_vm._s(_vm._f("truncate")(message.text)))])])], 1), _vm._v(" "), _c('hr')])
  }), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item text-center",
    attrs: {
      "href": "#"
    }
  }, [_c('strong', [_c('router-link', {
    attrs: {
      "exact": "",
      "to": {
        name: 'Mailbox',
        params: {
          type: 'messages'
        }
      }
    }
  }, [_vm._v("View all messages")])], 1)])], 2) : _vm._e()]), _vm._v(" "), _c('div', {
    staticClass: "tab-pane p-1",
    attrs: {
      "id": "notifications",
      "role": "tabpanel"
    }
  }, [_c('div', {
    staticClass: "header"
  }, [_c('strong', [_vm._v("You have " + _vm._s(_vm.user.notificationCount) + " notification(s)")])]), _vm._v(" "), (_vm.user.hasNotifications) ? _c('div', _vm._l((_vm.user.customData.notifications), function(notification) {
    return _c('div', [_c('div', {
      staticClass: "message"
    }, [_c('router-link', {
      staticClass: "dropdown-item",
      attrs: {
        "exact": "",
        "to": {
          name: 'Mailbox',
          params: {
            type: 'notifications'
          }
        }
      }
    }, [_c('div', [_c('small', {
      staticClass: "text-muted"
    }, [_vm._v(_vm._s(notification.from))]), _vm._v(" "), _c('small', {
      staticClass: "text-muted float-right mt-q"
    }, [_vm._v("\n                                    " + _vm._s(_vm._f("localeDateOrTimeToday")(notification.timeStamp)) + "\n                                ")])]), _vm._v(" "), _c('div', {
      staticClass: "text-truncate font-weight-bold"
    }, [_vm._v(_vm._s(notification.subject))]), _vm._v(" "), _c('div', {
      staticClass: "text-muted"
    }, [_vm._v(_vm._s(_vm._f("truncate")(notification.text)))])])], 1), _vm._v(" "), _c('hr'), _vm._v(" "), _c('a', {
      staticClass: "dropdown-item text-center",
      attrs: {
        "href": "#"
      }
    }, [_c('strong', [_c('router-link', {
      attrs: {
        "exact": "",
        "to": {
          name: 'Mailbox',
          params: {
            type: 'notifications'
          }
        }
      }
    }, [_vm._v("\n                                View all notifications\n                            ")])], 1)])])
  })) : _vm._e()])])])
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-c4224d7a", module.exports)
  }
}

/***/ }),

/***/ 679:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('header', {
    staticClass: "app-header navbar"
  }, [_c('button', {
    staticClass: "navbar-toggler mobile-sidebar-toggler hidden-lg-up",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("☰")]), _vm._v(" "), _c('a', {
    staticClass: "navbar-brand",
    attrs: {
      "href": "#"
    }
  }), _vm._v(" "), _vm._m(0), _vm._v(" "), _c('ul', {
    staticClass: "nav navbar-nav ml-auto"
  }, [_c('li', {
    staticClass: "nav-item dropdown"
  }, [_c('a', {
    staticClass: "nav-link dropdown-toggle nav-link",
    attrs: {
      "data-toggle": "dropdown",
      "href": "#",
      "role": "button",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('span', [_vm._v(_vm._s(_vm.user.fullName))]), _vm._v(" "), _vm._l((_vm.user.groups.items), function(item, index) {
    return _c('span', {
      staticClass: "hidden-md-down small",
      staticStyle: {
        "display": "none"
      }
    }, [_vm._v("\n                    " + _vm._s(item.name)), (index != (_vm.user.groups.items.length - 1)) ? _c('span', [_vm._v(",")]) : _vm._e()])
  })], 2), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right"
  }, [_vm._m(1), _vm._v(" "), _c('router-link', {
    staticClass: "dropdown-item",
    attrs: {
      "exact": "",
      "to": {
        name: 'Mailbox',
        params: {
          type: 'messages'
        }
      }
    }
  }, [_c('i', {
    staticClass: "icon-envelope-letter"
  }), _vm._v(" Messages\n                    "), _c('span', {
    staticClass: "tag",
    class: {
      'tag-success': _vm.user.hasMessages, 'tag-default': !_vm.user.hasMessages
    }
  }, [_vm._v("\n                        " + _vm._s(_vm.user.messageCount) + "\n                    ")])]), _vm._v(" "), _c('router-link', {
    staticClass: "dropdown-item",
    attrs: {
      "exact": "",
      "to": {
        name: 'Mailbox',
        params: {
          type: 'notifications'
        }
      }
    }
  }, [_c('i', {
    staticClass: "icon-bell"
  }), _vm._v(" Notifications\n                    "), _c('span', {
    staticClass: "tag",
    class: {
      'tag-success': _vm.user.hasNotifications, 'tag-default': !_vm.user.hasNotifications
    }
  }, [_vm._v("\n                        " + _vm._s(_vm.user.notificationCount) + "\n                    ")])]), _vm._v(" "), _vm._m(2)], 1)]), _vm._v(" "), _vm._m(3)])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('ul', {
    staticClass: "nav navbar-nav hidden-md-down"
  }, [_c('li', {
    staticClass: "nav-item"
  }, [_c('a', {
    staticClass: "nav-link navbar-toggler sidebar-toggler",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("☰")])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "dropdown-header text-center"
  }, [_c('strong', [_vm._v("Account")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "/login"
    }
  }, [_c('i', {
    staticClass: "fa fa-lock"
  }), _vm._v("Logout")])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('li', {
    staticClass: "nav-item hidden-md-down"
  }, [_c('a', {
    staticClass: "nav-link navbar-toggler aside-menu-toggler",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("☰")])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-cf978c6a", module.exports)
  }
}

/***/ }),

/***/ 680:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "container container-table"
  }, [_c('div', {
    staticClass: "row vertical-10p"
  }, [_c('div', {
    staticClass: "container"
  }, [_c('img', {
    staticClass: "center-block logo",
    attrs: {
      "src": __webpack_require__(585)
    }
  }), _vm._v(" "), _c('div', {
    staticClass: "text-center col-sm-6 col-sm-offset-3"
  }, [_c('h1', [_vm._v("You are lost.")]), _vm._v(" "), _c('h4', [_vm._v("This page doesn't exist.")]), _vm._v(" "), _c('router-link', {
    attrs: {
      "exact": "",
      "to": "/"
    }
  }, [_vm._v("Take me home.")])], 1)])])])
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-d66b7486", module.exports)
  }
}

/***/ }),

/***/ 681:
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('footer', {
    staticClass: "app-footer"
  }, [_c('div', {
    staticClass: "copyright"
  }, [_vm._v("Copyright © " + _vm._s(_vm.year) + " "), _c('strong', [_c('a', {
    attrs: {
      "href": "javascript:;"
    }
  }, [_vm._v(_vm._s(_vm.organization.name))])]), _vm._v(".  All rights reserved.")]), _vm._v(" "), _c('div', {
    staticClass: "powered-by"
  }, [_vm._v("Powered By Clinica Cloud Platform")])])
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-f68dcc9e", module.exports)
  }
}

/***/ }),

/***/ 684:
/***/ (function(module, exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(574);
if(typeof content === 'string') content = [[module.i, content, '']];
if(content.locals) module.exports = content.locals;
// add the styles to the DOM
var update = __webpack_require__(31)("26027bf5", content, false);
// Hot Module Replacement
if(false) {
 // When the styles change, update the <style> tags
 if(!content.locals) {
   module.hot.accept("!!../../node_modules/css-loader/index.js!../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-1af05ece\",\"scoped\":false,\"hasInlineConfig\":false}!../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Mailbox.vue", function() {
     var newContent = require("!!../../node_modules/css-loader/index.js!../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-1af05ece\",\"scoped\":false,\"hasInlineConfig\":false}!../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Mailbox.vue");
     if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
     update(newContent);
   });
 }
 // When the module is disposed, remove the <style> tags
 module.hot.dispose(function() { update(); });
}

/***/ }),

/***/ 685:
/***/ (function(module, exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(575);
if(typeof content === 'string') content = [[module.i, content, '']];
if(content.locals) module.exports = content.locals;
// add the styles to the DOM
var update = __webpack_require__(31)("d1ee3ddc", content, false);
// Hot Module Replacement
if(false) {
 // When the styles change, update the <style> tags
 if(!content.locals) {
   module.hot.accept("!!../../../node_modules/css-loader/index.js!../../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-1ec4ebb6\",\"scoped\":false,\"hasInlineConfig\":false}!../../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Setting.vue", function() {
     var newContent = require("!!../../../node_modules/css-loader/index.js!../../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-1ec4ebb6\",\"scoped\":false,\"hasInlineConfig\":false}!../../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Setting.vue");
     if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
     update(newContent);
   });
 }
 // When the module is disposed, remove the <style> tags
 module.hot.dispose(function() { update(); });
}

/***/ }),

/***/ 686:
/***/ (function(module, exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(576);
if(typeof content === 'string') content = [[module.i, content, '']];
if(content.locals) module.exports = content.locals;
// add the styles to the DOM
var update = __webpack_require__(31)("6e7daa88", content, false);
// Hot Module Replacement
if(false) {
 // When the styles change, update the <style> tags
 if(!content.locals) {
   module.hot.accept("!!../../../node_modules/css-loader/index.js!../../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-4c3529a0\",\"scoped\":false,\"hasInlineConfig\":false}!../../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Tables.vue", function() {
     var newContent = require("!!../../../node_modules/css-loader/index.js!../../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-4c3529a0\",\"scoped\":false,\"hasInlineConfig\":false}!../../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Tables.vue");
     if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
     update(newContent);
   });
 }
 // When the module is disposed, remove the <style> tags
 module.hot.dispose(function() { update(); });
}

/***/ }),

/***/ 687:
/***/ (function(module, exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(577);
if(typeof content === 'string') content = [[module.i, content, '']];
if(content.locals) module.exports = content.locals;
// add the styles to the DOM
var update = __webpack_require__(31)("2d9b68d8", content, false);
// Hot Module Replacement
if(false) {
 // When the styles change, update the <style> tags
 if(!content.locals) {
   module.hot.accept("!!../../../node_modules/css-loader/index.js!../../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-4da0d858\",\"scoped\":false,\"hasInlineConfig\":false}!../../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Accessioning.vue", function() {
     var newContent = require("!!../../../node_modules/css-loader/index.js!../../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-4da0d858\",\"scoped\":false,\"hasInlineConfig\":false}!../../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Accessioning.vue");
     if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
     update(newContent);
   });
 }
 // When the module is disposed, remove the <style> tags
 module.hot.dispose(function() { update(); });
}

/***/ }),

/***/ 688:
/***/ (function(module, exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(578);
if(typeof content === 'string') content = [[module.i, content, '']];
if(content.locals) module.exports = content.locals;
// add the styles to the DOM
var update = __webpack_require__(31)("795e7d74", content, false);
// Hot Module Replacement
if(false) {
 // When the styles change, update the <style> tags
 if(!content.locals) {
   module.hot.accept("!!../../../node_modules/css-loader/index.js!../../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-6a867329\",\"scoped\":false,\"hasInlineConfig\":false}!../../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./ClientAdmin.vue", function() {
     var newContent = require("!!../../../node_modules/css-loader/index.js!../../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-6a867329\",\"scoped\":false,\"hasInlineConfig\":false}!../../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./ClientAdmin.vue");
     if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
     update(newContent);
   });
 }
 // When the module is disposed, remove the <style> tags
 module.hot.dispose(function() { update(); });
}

/***/ }),

/***/ 689:
/***/ (function(module, exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(579);
if(typeof content === 'string') content = [[module.i, content, '']];
if(content.locals) module.exports = content.locals;
// add the styles to the DOM
var update = __webpack_require__(31)("61207406", content, false);
// Hot Module Replacement
if(false) {
 // When the styles change, update the <style> tags
 if(!content.locals) {
   module.hot.accept("!!../../../node_modules/css-loader/index.js!../../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-765e9c36\",\"scoped\":false,\"hasInlineConfig\":false}!../../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Worklist.vue", function() {
     var newContent = require("!!../../../node_modules/css-loader/index.js!../../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-765e9c36\",\"scoped\":false,\"hasInlineConfig\":false}!../../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Worklist.vue");
     if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
     update(newContent);
   });
 }
 // When the module is disposed, remove the <style> tags
 module.hot.dispose(function() { update(); });
}

/***/ }),

/***/ 690:
/***/ (function(module, exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(580);
if(typeof content === 'string') content = [[module.i, content, '']];
if(content.locals) module.exports = content.locals;
// add the styles to the DOM
var update = __webpack_require__(31)("8a66cfac", content, false);
// Hot Module Replacement
if(false) {
 // When the styles change, update the <style> tags
 if(!content.locals) {
   module.hot.accept("!!../../../node_modules/css-loader/index.js!../../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-7c6f53a3\",\"scoped\":false,\"hasInlineConfig\":false}!../../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Tasks.vue", function() {
     var newContent = require("!!../../../node_modules/css-loader/index.js!../../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-7c6f53a3\",\"scoped\":false,\"hasInlineConfig\":false}!../../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Tasks.vue");
     if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
     update(newContent);
   });
 }
 // When the module is disposed, remove the <style> tags
 module.hot.dispose(function() { update(); });
}

/***/ }),

/***/ 691:
/***/ (function(module, exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(581);
if(typeof content === 'string') content = [[module.i, content, '']];
if(content.locals) module.exports = content.locals;
// add the styles to the DOM
var update = __webpack_require__(31)("74eb55a0", content, false);
// Hot Module Replacement
if(false) {
 // When the styles change, update the <style> tags
 if(!content.locals) {
   module.hot.accept("!!../../node_modules/css-loader/index.js!../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-b139a0b8\",\"scoped\":false,\"hasInlineConfig\":false}!../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Main.vue", function() {
     var newContent = require("!!../../node_modules/css-loader/index.js!../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-b139a0b8\",\"scoped\":false,\"hasInlineConfig\":false}!../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./Main.vue");
     if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
     update(newContent);
   });
 }
 // When the module is disposed, remove the <style> tags
 module.hot.dispose(function() { update(); });
}

/***/ }),

/***/ 692:
/***/ (function(module, exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(582);
if(typeof content === 'string') content = [[module.i, content, '']];
if(content.locals) module.exports = content.locals;
// add the styles to the DOM
var update = __webpack_require__(31)("2766f838", content, false);
// Hot Module Replacement
if(false) {
 // When the styles change, update the <style> tags
 if(!content.locals) {
   module.hot.accept("!!../../node_modules/css-loader/index.js!../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-d66b7486\",\"scoped\":false,\"hasInlineConfig\":false}!../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./404.vue", function() {
     var newContent = require("!!../../node_modules/css-loader/index.js!../../node_modules/vue-loader/lib/style-rewriter.js?{\"id\":\"data-v-d66b7486\",\"scoped\":false,\"hasInlineConfig\":false}!../../node_modules/vue-loader/lib/selector.js?type=styles&index=0!./404.vue");
     if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
     update(newContent);
   });
 }
 // When the module is disposed, remove the <style> tags
 module.hot.dispose(function() { update(); });
}

/***/ }),

/***/ 697:
/***/ (function(module, exports) {

/* (ignored) */

/***/ }),

/***/ 698:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(272);


/***/ })

},[698]);