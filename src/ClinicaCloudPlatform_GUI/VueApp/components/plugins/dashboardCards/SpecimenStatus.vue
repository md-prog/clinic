<template>
    <div class="card card-accent-info">
        <div class="card-header">
            <div class="row">
                <div class="col-6">Specimen {{this.specimen.externalId === '' ? '# ' + this.specimen.id : this.specimen.externalId}} Status</div>
                <div class="col-6"><div class="tag tag-info float-right" v-if="currentWorkflow.available">Available</div></div>
            </div>
        </div>
        <div class="card-block p-0 text-nowrap">
            <div class="container-fluid">
                <div class="row mt-1 mb-1">
                    <div class="col-12">
                        <div class="row">
                            <div class="col-12">
                                <div class="progress">
                                    <div v-bind:class="'progress-bar ' + this.getWorkflowOnTimeStatus(this.getDueDate(this.currentWorkflow.currentStepTat, this.currentWorkflow.stepStarted))"
                                         v-bind:style="'width:' + this.getWorkflowPercent(currentWorkflow.steps, currentWorkflow.currentStep) + '%'"
                                         v-bind:aria-valuenow="getWorkflowPercent(currentWorkflow.steps, currentWorkflow.currentStep)"
                                         aria-valuemin="0"
                                         aria-valuemax="100">{{currentWorkflow.currentStep}} {{currentWorkflow.stepStarted | localeDate}}</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-12">
                        <div class="row">
                            <div class="col-md-auto col-12">
                                <label class="label-black">Workflow:</label>
                            </div>
                            <div class="col-md-auto col-12">
                                {{currentWorkflow.name}}
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-auto col-12">
                                <label class="labLabel label-black">Laboratory:</label>
                            </div>
                            <div class="col-md-auto col-12">
                                {{currentWorkflow.laboratory}}
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-auto col-12">
                                <label class="departmentLabel label-black">Department:</label>
                            </div>
                            <div class="col-md-auto col-12">
                                {{currentWorkflow.department}}
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-auto col-12">
                                <label class="locationLabel label-black">Location:</label>
                            </div>
                            <div class="col-md-auto col-12">
                                {{currentWorkflow.location}}
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-12">
                        <div class="row">
                            <div class="col-md-auto col-12">
                                <label class="label-black">Due:</label>
                            </div>
                            <div class="col-md-auto col-12">
                                {{getDueDate(currentWorkflow.currentStepTat, currentWorkflow.stepStarted) | localeDate}}
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-auto col-12">
                                <label class="label-black">Updated:</label>
                            </div>
                            <div class="col-md-auto col-12">
                                {{currentWorkflow.lastUpdated | localeDate}}
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-auto col-12">
                                <label class="label-black">User:</label>
                            </div>
                            <div class="col-md-auto col-12">
                                {{currentWorkflow.userFullName}}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script src="./SpecimenStatus.vue.js"></script>