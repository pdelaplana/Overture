import { NotificationService } from './../../_services/notification.service';
import { AuthenticationService } from './../../_services/authentication.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  public title: string;
  public submitted: boolean;
  public signinForm : FormGroup;
  private returnUrl: string;


  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private notificationService: NotificationService,
    private route: ActivatedRoute,
    private router: Router
  ) { 
    this.title = "We're glad to see you again!!";
  }


  ngOnInit() {
    this.signinForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get email() { return this.signinForm.controls.email; }
  get password() { return this.signinForm.controls.password; }

  onSignin(){
    this.submitted = true;
    this.authenticationService.loginWithCredentials(this.email.value, this.password.value).subscribe(
      user=>{
        //alert('SUCCESS!! :-)\n\n' + JSON.stringify(user))
        this.notificationService.success('You have successfully logged in');
 
        this.router.navigate([this.returnUrl]);
      },
      error=>{

      }
    );
  }

}
