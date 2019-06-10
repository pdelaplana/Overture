import { MustMatch } from '@app/_validators/must-match.validator';
import { Router } from '@angular/router';
import { LoggingService } from '@app/_services/logging.service';
import { NotificationService } from '@app/_services/notification.service';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegistrationService } from '@app/_services/registration.service';
import { ValidationService } from '@app/_services/validation.service';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {
  registrationForm : FormGroup;
  submitted = false;

  @Input() selectedAccountType:string = "";

  constructor(
    private registrationService: RegistrationService,
    private validationService: ValidationService,
    private notificationService: NotificationService,
    private loggingService: LoggingService,
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    this.registrationForm = this.formBuilder.group({
      accountType: ['Personal', Validators.required],
      email: ['', [Validators.required, Validators.email], this.validationService.checkEmailIsUnique.bind(this.validationService)],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, {
      validator: MustMatch ('password', 'confirmPassword')
    });
    if (this.selectedAccountType)
      this.accountType.setValue(this.selectedAccountType)
  }

  // convenience getters for easy access to form fields
  get f() { return this.registrationForm.controls; }
  get accountType() { return this.registrationForm.controls.accountType; }
  get email() { return this.registrationForm.controls.email; }
  get password() { return this.registrationForm.controls.password; }

  setAccountType(accountType:string){
    this.accountType.setValue(accountType);
  }

  onSubmit(){
    this.submitted = true;

    // stop here if form is invalid
    if (!this.registrationForm.valid) {
        return;
    }
    // else
    this.registrationService.register({ 
      email: this.email.value,
      password: this.password.value,
      accountType: this.accountType.value 
    })
    .subscribe(
      user=>{
        alert('SUCCESS!! :-)\n\n' + JSON.stringify(user))
        this.notificationService.success('You have successfully registered');
 
        this.router.navigate(["/manage"]);
      },
      error=>{

      }
    )


    
  }


}
