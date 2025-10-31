import { Routes } from '@angular/router';
import { MapComponent } from './components/map-component/map-component';
import { FeedComponent } from './components/feed-component/feed-component';
import { DetailComponent } from './components/detail-component/detail-component';
import { UserComponent } from './components/user-component/user-component';
import { NotFoundComponent } from './components/not-found-component/not-found-component';
import { NewReportComponent } from './components/new-report-component/new-report-component';

export const routes: Routes = [
    {path: "", redirectTo: "/map", pathMatch: "full"},
    {path: "map", component: MapComponent},
    {path: "feed", component: FeedComponent},
    {path: "detail/:id", component: DetailComponent},
    {path: "user", component: UserComponent},
    {path: "new", component: NewReportComponent},
    {path: "**", component: NotFoundComponent}
];
