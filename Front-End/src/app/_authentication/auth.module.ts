import { NgModule, Optional, SkipSelf } from '@angular/core'; 
import { AuthService } from './auth.service';
import { AuthGuard } from './auth.guard';


 

@NgModule({
  imports: [
    
  ], 
  providers: [
    AuthService,
    AuthGuard    
  ]
})
export class AuthModule {

  constructor(@Optional() @SkipSelf() parentModule: AuthModule) {
    // Import guard
    if (parentModule) {
      throw new Error(`${parentModule} has already been loaded. Import Auth module in the AppModule only.`);
    }
  }

}