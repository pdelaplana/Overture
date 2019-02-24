import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,  Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { RegistrationService } from '@app/_services/registration.service';
import { MustMatch } from '@app/_validators/must-match.validator';
import { ValidationService } from '@app/_services/validation.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registrationForm : FormGroup;
  submitted = false;

  constructor(
    private registrationService: RegistrationService,
    private validationService: ValidationService,
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    
    this.registrationForm = this.formBuilder.group({
      registerType: ['personal', Validators.required],
      email: ['', [Validators.required, Validators.email], this.validationService.checkEmailIsUnique.bind(this.validationService)],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, {
      validator: MustMatch ('password', 'confirmPassword')
    });

  }

  // convenience getters for easy access to form fields
  get f() { return this.registrationForm.controls; }
  get registerType() { return this.registrationForm.controls.registerType; }
  get email() { return this.registrationForm.controls.email; }
  get password() { return this.registrationForm.controls.password; }

  setAccountType(accountType:string){
    this.registerType.setValue(accountType);
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
      registerAsBusiness: (this.registerType.value == 'business')
    })
    .subscribe(user=>{
      alert('SUCCESS!! :-)\n\n' + JSON.stringify(user))
      this.router.navigate(["/manage"]);
    })


    
  }


}
