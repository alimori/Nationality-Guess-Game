import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { GamePageComponent } from './pages/game-page/game-page.component';


const routes: Routes = [
  { path: '', redirectTo: "start-page", pathMatch: 'full' },
  { path: 'home-page', component: HomePageComponent, data: { title: 'home page' } },
  { path: 'game-page', component: GamePageComponent, data: { title: 'game page' } },
  { path: '**', redirectTo: "home-page" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
