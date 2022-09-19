import { Input, OnChanges, OnInit, Directive } from '@angular/core';

@Directive()
export class SpinnerComponent implements OnInit, OnChanges {
    toolThemes: ToolThemes[] = [
    {name:"th-tool-wi", count: 7},
    {name: "th-tool-nb", count:5}];

    @Input('tool-class') toolClass: string = "";

    public customStyleClass: string = "";

    ngOnInit(): void {
        this.setCustomStyle();
    }

    ngOnChanges(): void {
        this.setCustomStyle();
    }

    private setCustomStyle() {
        var themeCount = this.toolThemes.find(x => x.name == this.toolClass);

        if (themeCount != null) {
            this.customStyleClass = `${this.toolClass}-${this.randomInt(1, themeCount.count)}`;
        } else {
            this.customStyleClass = this.toolClass;
        }
    }

    private randomInt(min: number, max: number) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
}

interface ToolThemes {
    name: string;
    count: number;
};
