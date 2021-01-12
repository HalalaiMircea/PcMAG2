import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../services/authentication.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    hide = true;
    loginForm: FormGroup;
    submitted = false;
    private readonly returnUrl: string;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authService: AuthenticationService,
        private snackBar: MatSnackBar
    ) {
        // redirect to home if already logged in
        if (this.authService.currentUserValue) {
            this.router.navigate(['/']);
        }
        this.loginForm = this.formBuilder.group({
            email: new FormControl('', [Validators.required, Validators.email]),
            password: new FormControl('', Validators.required)
        });

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
        console.log(this.returnUrl);
    }

    ngOnInit(): void {
    }

    // convenience getter for easy access to form fields
    get fc(): { [p: string]: AbstractControl } {
        return this.loginForm.controls;
    }

    onSubmit(): void {
        this.submitted = true;

        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }
        this.authService
            .login(this.fc.email.value, this.fc.password.value)
            .subscribe(
                () => this.router.navigate([this.returnUrl]),
                error => this.snackBar.open(error, undefined, { duration: 3500 })
            );
    }
}
