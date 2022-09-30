import Vue from "vue";
import Router from "vue-router";
import firebase from "firebase";
import Userauth from "../auth/js/index";

import Body from "../components/body";
import Auth from "../auth/auth";

/* Auth */
import login from "../auth/login";
import callback from "../pages/callback";
import Register from "../auth/register";




/* Error Pages */
import Error400 from "../errors/error_400";
import Error401 from "../errors/error_401";
import Error403 from "../errors/error_403";
import Error404 from "../errors/error_404";
import Error500 from "../errors/error_500";
import Error503 from "../errors/error_503";

/* Dashboards */
import Default from "../pages/dashboard/default";


/* Form */
import FormWizrd from "../pages/forms/form_wizard";
import FormValidation from "../pages/forms/form_validation";
import FormBaseInputs from "../pages/forms/form_base_inputs";
import FormCheckboxRadio from "../pages/forms/form_checkbox_radio";
import FormInputGroups from "../pages/forms/form_input_groups";
import FormMegaOptions from "../pages/forms/form_mega_options";
/* Form Widgets */
import FormDatepicker from "../pages/form_widgets/datepicker";
import FormSelect2 from "../pages/form_widgets/select2";
import FormSwitch from "../pages/form_widgets/switch";
import FormTypeahead from "../pages/form_widgets/typeahead";
import FormClipboard from "../pages/form_widgets/clipboard";
import FormTouchspin from "../pages/form_widgets/touchspin";

/* bootstrap tables */
import BootstrapBasic from "../pages/tables/bootstrap/basic";
import BootstrapSizing from "../pages/tables/bootstrap/sizing";
import BootstrapBorder from "../pages/tables/bootstrap/border";
import BootstrapStyling from "../pages/tables/bootstrap/styling";
/* datatable tables */
import DatatableBasic from "../pages/tables/datatable/basic_init";
import DatatableSelectDelete from "../pages/tables/datatable/select_delete";
import FilterTable from "../pages/tables/datatable/filter";
import DatatableExport from "../pages/tables/datatable/data_export";

/* calendar */
import Calendar from "../pages/calendar/fullcalendar";

/* vuejs smart table */
import SmartTable from "../pages/tables/vuejs_smart_table/basic";


/* User Profile */
import UserEditProfile from "../pages/users/edit-profile";






// component

Vue.use(Router);

const routes = [
    { path: "", 
    redirect: { 
        name: "Login 1" 
      } 
    },
    
    {
        path: "/dashboard",
        redirect: { 
            name: "default" 
          } ,
        component: Body,
        meta: {
            requiresAuth: true,
        },
        children: [
            {
                path: "default",
                name: "default",
                component: Default,
                meta: {
                    title: "Default Dashboard | Cuba - Premium Admin Template",
                },
            },
           
        ],
    },

    {
        path: "/users",
        component: Body,
        children: [
            {
                path: "edit",
                name: "UserEditProfile",
                component: UserEditProfile,
                meta: {
                    title: "serEditProfile | Cuba - Premium Admin Template",
                },
            },

        ],
    },
   
    {
        path: "/form",
        component: Body,
        children: [
            {
                path: "wizard",
                name: "FormWizard",
                component: FormWizrd,
                meta: {
                    title: "FormWizrd | Cuba - Premium Admin Template",
                },
            },
            {
                path: "validation",
                name: "FormValidation",
                component: FormValidation,
                meta: {
                    title: "FormValidation | Cuba - Premium Admin Template",
                },
            },
            {
                path: "inputs",
                name: "FormBaseInputs",
                component: FormBaseInputs,
                meta: {
                    title: "FormBaseInputs | Cuba - Premium Admin Template",
                },
            },
            {
                path: "checkbox-radio",
                name: "FormCheckboxRadio",
                component: FormCheckboxRadio,
                meta: {
                    title: "FormCheckboxRadio | Cuba - Premium Admin Template",
                },
            },
            {
                path: "input-groups",
                name: "FormInputGroups",
                component: FormInputGroups,
                meta: {
                    title: "FormInputGroups | Cuba - Premium Admin Template",
                },
            },
            {
                path: "mega-options",
                name: "FormMegaOptions",
                component: FormMegaOptions,
                meta: {
                    title: "FormMegaOptions | Cuba - Premium Admin Template",
                },
            },
            {
                path: "datepicker",
                name: "FormDatepicker",
                component: FormDatepicker,
                meta: {
                    title: "FormDatepicker | Cuba - Premium Admin Template",
                },
            },
            {
                path: "select2",
                name: "FormSelect2",
                component: FormSelect2,
                meta: {
                    title: "FormSelect2 | Cuba - Premium Admin Template",
                },
            },
            {
                path: "switch",
                name: "FormSwitch",
                component: FormSwitch,
                meta: {
                    title: "FormSwitch | Cuba - Premium Admin Template",
                },
            },
            {
                path: "typeahead",
                name: "FormTypeahead",
                component: FormTypeahead,
                meta: {
                    title: "FormTypeahead | Cuba - Premium Admin Template",
                },
            },
            {
                path: "clipboard",
                name: "FormClipboard",
                component: FormClipboard,
                meta: {
                    title: "FormClipboard | Cuba - Premium Admin Template",
                },
            },
            {
                path: "touchspin",
                name: "FormTouchspin",
                component: FormTouchspin,
                meta: {
                    title: "FormTouchspin | Cuba - Premium Admin Template",
                },
            },
            {
                path: "mega-options",
                name: "Form Mega Options",
                component: FormMegaOptions,
                meta: {
                    title: "FormMegaOptions | Cuba - Premium Admin Template",
                },
            },
        ],
    },
    {
        path: "/table",
        component: Body,
        children: [
            {
                path: "basic",
                name: "BootstrapBasic",
                component: BootstrapBasic,
                meta: {
                    title: "BootstrapBasic | Cuba - Premium Admin Template",
                },
            },
            {
                path: "sizing",
                name: "BootstrapSizing",
                component: BootstrapSizing,
                meta: {
                    title: "BootstrapSizing | Cuba - Premium Admin Template",
                },
            },
            {
                path: "border",
                name: "BootstrapBorder",
                component: BootstrapBorder,
                meta: {
                    title: "BootstrapBorder | Cuba - Premium Admin Template",
                },
            },
            {
                path: "styling",
                name: "BootstrapStyling",
                component: BootstrapStyling,
                meta: {
                    title: "BootstrapStyling | Cuba - Premium Admin Template",
                },
            },
            {
                path: "/datatable-basic",
                name: "DatatableBasic",
                component: DatatableBasic,
                meta: {
                    title: "DatatableBasic | Cuba - Premium Admin Template",
                },
            },
            {
                path: "/datatable-select-delete",
                name: "DatatableSelectDelete",
                component: DatatableSelectDelete,
                meta: {
                    title: "DatatableSelectDelete | Cuba - Premium Admin Template",
                },
            },
            {
                path: "/filter-table",
                name: "FilterTable",
                component: FilterTable,
                meta: {
                    title: "FilterTable | Cuba - Premium Admin Template",
                },
            },
            {
                path: "/datatable-export",
                name: "DatatableExport",
                component: DatatableExport,
                meta: {
                    title: "DatatableExport | Cuba - Premium Admin Template",
                },
            },
            {
                path: "smarttable",
                name: "SmartTable",
                component: SmartTable,
                meta: {
                    title: "SmartTable | Cuba - Premium Admin Template",
                },
            },
        ],
    },
    {
        path: "/app",
        component: Body,
        children: [          
            {
                path: "calendar",
                name: "Calendar",
                component: Calendar,
                meta: {
                    title: "Calendar | Cuba - Premium Admin Template",
                },
            },
        ],
    },
    
    {
        path: "/auth",
        component: Auth,
        children: [
            {
                path: "login",
                name: "Login 1",
                component: login,
                meta: {
                    title: " login | Cuba - Premium Admin Template",
                },
            },
            {
                path: "register",
                name: "register 1",
                component: Register,
                meta: {
                    title: " Register | Cuba - Premium Admin Template",
                },
            },
        ],
    },
    
    {
        path: "/callback",
        name: "callback",
        component: callback,
        meta: {
            title: "Auth0",
        },
    },
    {
        path: "/error-400",
        name: "Error400",
        component: Error400,
        meta: {
            title: "Error400 | Cuba - Premium Admin Template",
        },
    },
    {
        path: "/error-401",
        name: "Error401",
        component: Error401,
        meta: {
            title: "Error401 | Cuba - Premium Admin Template",
        },
    },
    {
        path: "/error-403",
        name: "Error403",
        component: Error403,
        meta: {
            title: "Error403 | Cuba - Premium Admin Template",
        },
    },
    {
        path: "/error-404",
        name: "Error404",
        component: Error404,
        meta: {
            title: "Error404 | Cuba - Premium Admin Template",
        },
    },
    {
        path: "/error-500",
        name: "Error500",
        component: Error500,
        meta: {
            title: "Error500 | Cuba - Premium Admin Template",
        },
    },
    {
        path: "/error-503",
        name: "Error503",
        component: Error503,
        meta: {
            title: "Error503 | Cuba - Premium Admin Template",
        },
    },

 
];

const router = new Router({
    routes,
    base: process.env.BASE_URL,
    mode: "history",
    linkActiveClass: "active",
    scrollBehavior() {
        return { x: 0, y: 0 };
    },
});

router.beforeEach((to, from, next) => {
    firebase.auth().onAuthStateChanged(() => {
        if (to.meta.title) document.title = to.meta.title;
        const CurrentUser = firebase.auth().currentUser;
        const path = ["/auth/login", "/auth/register"];
        const JWTuser = localStorage.getItem("user");
        if (
            path.includes(to.path) ||
            to.path === "/callback" ||
            CurrentUser ||
            Userauth.isAuthenticatedUser() ||
            JWTuser
        ) {
            return next();
        }
        next("/dashboard");
    });
});

export default router;
