import { Component, OnInit } from '@angular/core';
import { LoaderService } from '../_services/loader.service';
import { Subject } from 'rxjs';

@Component({
    selector: 'app-loader',
    templateUrl: './loader.component.html',
    styleUrls: ['./loader.component.css']
})

export class LoaderComponent implements OnInit{
    color = 'primary';
    mode = 'indeterminate';
    value = 30;
    isLoading: Subject<boolean>

    constructor(private loaderService: LoaderService) { }

    ngOnInit()
    {
        setTimeout(() => this.isLoading = this.loaderService.isLoading, 500);
    }

}
