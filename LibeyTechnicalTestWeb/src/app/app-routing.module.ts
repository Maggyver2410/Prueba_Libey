import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { UsercardsComponent } from "./User/user/usercards/usercards.component";
import { UsermaintenanceComponent } from "./User/user/usermaintenance/usermaintenance.component";
import { UserlistComponent } from "./User/user/userlist/userlist.component";
const routes: Routes = [
	{
		path: "",
		redirectTo: "/user",
		pathMatch: "full",
	},
	{
		path: "user",
		children: [
			{ path: "card", component: UsercardsComponent },
			{ path: "maintenance", component: UsermaintenanceComponent },
			{ path: "userlist", component: UserlistComponent },
			{ path: "maintenance/:id/edit", component: UsermaintenanceComponent },
			{ path: '**', component: UsercardsComponent },
		],
	},
	{ path: "**", component: AppComponent },
];
@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}