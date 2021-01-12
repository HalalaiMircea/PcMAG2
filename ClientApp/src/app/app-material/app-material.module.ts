import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ],
    exports: [
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatToolbarModule,
        MatCardModule,
        MatIconModule,
        MatSnackBarModule
    ]
})
export class AppMaterialModule {
}
