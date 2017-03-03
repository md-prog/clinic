<template>
    <div class="sidebar">
        <nav class="sidebar-nav open">
            <form>
                <h5>Main Menu</h5>
                <div class="form-group p-h mb-0 ml-h mr-h">
                    <input type="text" name="search" id="search" class="search form-control" data-toggle="hideseek" placeholder="Search Menu" data-list=".search-nav">
                    <!--<span class="input-group-btn">
                        <button type="submit" name="search" id="search-btn" class="btn btn-flat">
                            <i class="fa fa-search"></i>
                        </button>
                    </span>-->
                </div>
            </form>
            <!-- Sidebar Menu -->
            <div v-for="route in this.$router.options.routes">
                <ul class="nav search-nav">
                    <li class="nav-title">
                        <a>{{ route.name }}</a>
                    </li>
                    <li v-for="childRoute in route.children" class="nav-item">                        
                        <router-link tag="a" :to="route.path + childRoute.path" class="nav-link">
                            <i v-bind:class="childRoute.meta == null ? defaultRouteIconClasses : childRoute.meta.iconClass"></i>
                            {{childRoute.name }}
                        </router-link>
                    </li>
                </ul>
            </div>
            <!--<ul class="nav search-nav">

                <li class="nav-title">
                    Catalog/Worklists
                </li>

                <li class="nav-item">
                    <router-link exact to="/Specimenlist/catalog" class="nav-link">
                        <i class="fa fa-list"></i>
                        Specimen Catalog
                        <span class="tag tag-primary">NEW</span>
                    </router-link>
                </li>
                <li class="nav-item">
                    <router-link exact to="/Specimenlist/inventory" class="nav-link">
                        <i class="fa fa-list-alt"></i>
                        Specimen Inventory
                        <span class="tag tag-primary">NEW</span>
                    </router-link>
                </li>
                <li class="nav-item">
                    <router-link exact to="/worklist/cases" class="nav-link">
                        <i class="fa fa-list-alt"></i>
                        Case Worklist
                    </router-link>
                </li>
                <li class="nav-item">
                    <router-link exact to="/worklist/Specimens" class="nav-link">
                        <i class="fa fa-table"></i>
                        Specimen Worklist
                    </router-link>
                </li>

                <li class="nav-title">
                    Specimens
                </li>

                <li class="nav-item">
                    <router-link exact to="/accessioning/4/clinica" class="nav-link">
                        <i class="icon-chemistry"></i> <span class="page"><span class="accessionLabel">Accession</span> Specimens</span>
                    </router-link>
                </li>
                <li class="nav-title">
                    Settings/Admin
                </li>
                <li class="nav-item">
                    <router-link exact to="/admin/clientadmin" class="nav-link">
                        <i class="icon-wrench"></i><span class="page">Client Admin</span>
                    </router-link>
                </li>


                <li class="nav-title">
                    Etc
                </li>

                <li class="nav-item">
                    <router-link exact to="/" class="nav-link">
                        <i class="icon-speedometer"></i> Dashboard #1<span class="tag tag-info">NEW</span>
                    </router-link>
                </li>
                <li class="nav-item">
                    <router-link exact to="/dashboard2" class="nav-link">
                        <i class="icon-grid" /><span class="page">Dashboard #2</span>
                    </router-link>
                </li>
            </ul>-->
        </nav>
    </div>
</template>
<script>
    module.exports = {
        name: 'Sidebar',
        computed: {
            defaultRouteIconClasses: function () { return "fa fa-list"; }
        }
    };
</script>
