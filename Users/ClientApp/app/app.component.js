var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { DataService } from './data.service';
import { User } from './users';
var AppComponent = /** @class */ (function () {
    function AppComponent(dataService) {
        this.dataService = dataService;
        this.total = 0; // Total users.
        this.active = 0; // Active users.
        this.user = new User(); // The value of user.
    }
    // Initialization data.
    AppComponent.prototype.ngOnInit = function () {
        this.loadUsers();
    };
    // Finding the coutn of total 
    // and active users.
    AppComponent.prototype.setUsers = function () {
        this.total = this.users.length;
        this.getActiveUsers();
    };
    //  Getting active users.
    AppComponent.prototype.getActiveUsers = function () {
        this.active = 0;
        for (var _i = 0, _a = this.users; _i < _a.length; _i++) {
            var el = _a[_i];
            if (el.active) {
                this.active++;
            }
        }
    };
    // Loading users from database.
    AppComponent.prototype.loadUsers = function () {
        var _this = this;
        this.dataService.getUsers()
            .subscribe(function (data) { return _this.users = data; });
    };
    // Saving modified user.
    AppComponent.prototype.save = function () {
        var _this = this;
        this.dataService.updateUser(this.user)
            .subscribe(function (data) { return _this.loadUsers(); });
        this.user = new User();
    };
    // Updating data.
    AppComponent.prototype.changeStatus = function (u) {
        this.user = u;
        this.user.active = !this.user.active;
        this.save();
    };
    AppComponent = __decorate([
        Component({
            selector: 'app',
            templateUrl: './app.component.html',
            providers: [DataService]
        }),
        __metadata("design:paramtypes", [DataService])
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
//# sourceMappingURL=app.component.js.map